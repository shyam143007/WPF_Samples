using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class GlobalErrorHandler : IErrorHandler
    {
        public bool HandleError(Exception error)
        {
            return true;
        }

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            if (error is FaultException)
                return;

            string errorDescription = string.Format("{0} {1} {2}", error.Message, 
                                                                   Environment.NewLine,
                                                                   error.StackTrace);
            FaultException exception = new FaultException(errorDescription);
            MessageFault msgFault = exception.CreateMessageFault();
            fault = Message.CreateMessage(version, msgFault, null);
        }
    }
}
