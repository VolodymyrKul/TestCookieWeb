using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TestCookieWeb.Core.Abstractions;

namespace TestCookieWeb.Services.Base
{
    public class BaseService
    {
        protected IUnitOfWork unitOfWork;
        protected IMapper _mapper;
        public BaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
