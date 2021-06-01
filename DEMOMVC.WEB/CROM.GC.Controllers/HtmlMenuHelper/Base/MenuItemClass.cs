using System;
using System.Collections.Generic;

namespace CROM.GC.Controllers.HtmlMenuHelper.Base
{
    public enum MenuType
    {
        submenu,
        Top
    }

    public class MenuViewModel<T>
    {
        public IList<T> MenuItems = new List<T>();
    }

    public class MvcMenuItem : IItem<MvcMenuItem>
    {
        public string Text { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string IconImage { get; set; }
        public MenuType MnuTyp { get; set; }

        public List<MvcMenuItem> MenuChildren = new List<MvcMenuItem>();

        public MvcMenuItem AddItem(string txt)
        {
            MvcMenuItem mi = new MvcMenuItem() { Text = txt };
            MenuChildren.Add(mi);
            return mi;
        }

        public MvcMenuItem AddItem(string txt, string controller, string action, string icon)
        {
            MvcMenuItem mi = new MvcMenuItem() { Text = txt, Action = action, Controller = controller, IconImage = icon };
            MenuChildren.Add(mi);
            return mi;
        }

        public override string ToString()
        {
            return Text;
        }

        public IList<MvcMenuItem> GetChildren()
        {
            return MenuChildren;
        }
    }

    public interface IItem<T>
    {
        IList<T> GetChildren();
    }
}
