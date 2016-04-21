using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace Service_Starter
{
    [RunInstaller(true)]
    public partial class SampleServiceInstaller : System.Configuration.Install.Installer
    {
        public SampleServiceInstaller()
        {
            InitializeComponent();
        }
    }
}
