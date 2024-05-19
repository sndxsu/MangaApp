using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.UI
{

    public class ThemeControl
    {
        readonly private MaterialSkinManager themeManager;
        MaterialForm controlledForm;

        public ThemeControl(MaterialForm materialForm)
        {
            themeManager = MaterialSkinManager.Instance;
            controlledForm = materialForm;
        }
        public void Initialize()
        {
            themeManager.AddFormToManage(controlledForm);
            themeManager.Theme = MaterialSkinManager.Themes.DARK;
        }
    }
}
