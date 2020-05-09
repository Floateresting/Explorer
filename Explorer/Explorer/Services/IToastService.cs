using System;
using System.Collections.Generic;
using System.Text;

namespace Explorer.Services {
    public interface IToastService {
        void LongAlert(string message);
        void ShortAlert(string message);
    }
}
