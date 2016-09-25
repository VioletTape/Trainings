using System;
using System.Collections.Generic;

namespace Application.Services.Interfaces {
    public interface IDataFacade {
        List<T> Get<T>(Func<T, bool> spec);
    }
}