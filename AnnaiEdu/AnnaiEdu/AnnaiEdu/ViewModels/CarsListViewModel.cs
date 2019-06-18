using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnnaiEdu.ViewModels
{
    public class CarsListViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => throw new NotImplementedException();

        public IScreen HostScreen => throw new NotImplementedException();
    }
}
