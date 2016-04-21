using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class GlobalErrorBehavior : Attribute, IServiceBehavior
    {
        readonly Type errorHandlerType;

        public GlobalErrorBehavior(Type errorHandlerType)
        {
            this.errorHandlerType = errorHandlerType;
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            IErrorHandler handler = Activator.CreateInstance(errorHandlerType) as IErrorHandler;

            foreach (ChannelDispatcherBase item in serviceHostBase.ChannelDispatchers)
            {
                ChannelDispatcher channelDispatcher = item as ChannelDispatcher;
                if (channelDispatcher.ErrorHandlers != null)
                    channelDispatcher.ErrorHandlers.Add(handler);
            }
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }
    }
}
