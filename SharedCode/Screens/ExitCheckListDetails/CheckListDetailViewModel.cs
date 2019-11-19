using System;
using System.Collections.Generic;
using System.Text;

namespace SharedCode
{
    public class ExitCheckListDetailViewModel
    {
        ExitCheckListDetailDataProvider exitCheckListDetailDataProvider;
        public ExitCheckListDetailViewModel()
        {
            exitCheckListDetailDataProvider = new ExitCheckListDetailDataProvider();
        }
    }
}
