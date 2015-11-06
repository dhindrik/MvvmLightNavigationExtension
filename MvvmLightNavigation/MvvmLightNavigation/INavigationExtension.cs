using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLightNavigationExtension
{
    public interface INavigationExtension
    {
        void OpenModal(string key);
        void CloseModal();
    }
}
