﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web;
using Ninject;
using SportsStore.WebUI.Infrastructure;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using Moq;
using SportsStore.Domain.Concrete;

namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
                ? null
                : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            // put additional bindings here 
            ninjectKernel.Bind<IProductRepository>().To<EFProductRepository>();
        }
    }
}