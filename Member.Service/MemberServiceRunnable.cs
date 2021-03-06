﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System.Configuration;
using Microsoft.Owin.Hosting;

namespace Member.Service
{
    public class MemberServiceRunnable
    {
        public static IWindsorContainer Container = new WindsorContainer();

        private IDisposable httpServer;

        public MemberServiceRunnable()
        {
            Container.Install(FromAssembly.This());
        }
        public void Start()
        {
            httpServer = WebApp.Start<OwinStartup>(url: ConfigurationManager.AppSettings["Url"]);

        }

        public void Stop()
        {
            httpServer?.Dispose();
            Container.Dispose();
        }
    }
}
