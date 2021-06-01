using System;
using System.Collections.Generic;
using System.Demo.Tools.helpers;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;


namespace CROM.GC.Controllers.HtmlMenuHelper.Base
{
    public abstract class BaseHtmlTagEngine<T> where T : IItem<T>
    {
        //protected static readonly ILog log = LogManager.GetLogger(typeof(BaseHtmlTagEngine<T>));
        protected int _CntNumber = 0;
        TagContainer _TopTagContainer;
        string _OutString;
        protected HtmlHelper _htmlHelper;

        public BaseHtmlTagEngine(HtmlHelper htmlHelper)
        {
            _htmlHelper = htmlHelper;
        }

        public TagContainer TopTagCont
        {
            get { return _TopTagContainer; }
        }

        public void BuildTreeStruct(MenuViewModel<T> mod)
        {
            _CntNumber = 0;

            try
            {
                _TopTagContainer = new TagContainer(ref _CntNumber, null);

                foreach (T Mi in mod.MenuItems)
                {
                    BuildTagContainer(Mi, _TopTagContainer);
                }
            }
            catch (Exception ex)
            {
                HelpLogging.Write(TraceLevel.Error, string.Concat( this.GetType().Name,".", MethodBase.GetCurrentMethod().Name), ex);
                throw new Exception(HelpException.mTraerMensaje(ex).Message);
            }
        }

        public string Build()
        {
            try
            {
                while (true)
                {
                    TagContainer tc = GetNoChildNode(_TopTagContainer);

                    bool PrcComplete = false;

                    PropagateInnerContentOneLevelUp(tc, ref PrcComplete);

                    if (PrcComplete)
                        break;
                }
            }
            catch (Exception ex)
            {
                HelpLogging.Write(TraceLevel.Error, string.Concat(this.GetType().Name,".", MethodBase.GetCurrentMethod().Name), ex);
                throw new Exception(HelpException.mTraerMensaje(ex).Message);
            }

            return _OutString;
        }

        /// <summary>
        /// Cutting the branches and rescanning the tree, and again
        /// </summary>
        /// <param name="tc_int"></param>
        /// <param name="ProcessingComplete"></param>
        void PropagateInnerContentOneLevelUp(TagContainer tc_int, ref bool ProcessingComplete)
        {
            TagContainer tc = tc_int;

            while (tc != null)
            {
                if (tc.ParentContainer != null)
                {
                    if (tc.ParentContainer.Tb != null)
                    {
                        tc.ParentContainer.Tb.InnerHtml += tc.Tb.ToString();
                        _OutString = tc.ParentContainer.Tb.ToString();
                    }
                    else
                    {
                        ProcessingComplete = true;
                        break; // dummy or invalid container
                    }

                    if (tc.ParentContainer.ChildrenContainers.Count > 1)
                    {
                        tc.ParentContainer.ChildrenContainers.Remove(tc);// this branch has to be cut off, we move all the content up
                        break;
                    }

                    tc = tc.ParentContainer;// moving up the tree
                }
                else
                {
                    ProcessingComplete = true;
                    break;
                }
            }
        }

        TagContainer GetNoChildNode(TagContainer tc)
        {
            List<TagContainer> ContsList = new List<TagContainer>();

            CollectNoChildNodes(tc, ContsList);

            return ContsList.First();
        }

        void CollectNoChildNodes(TagContainer tc, List<TagContainer> ContsList)
        {
            if (tc == null)
                return;

            if (tc.ChildrenContainers.Count == 0)
            {
                ContsList.Add(tc);
            }

            foreach (TagContainer tcc in tc.ChildrenContainers)
            {
                CollectNoChildNodes(tcc, ContsList);
            }
        }

        protected static bool HasChildren(T itm)
        {
            if (itm == null)
                return false;

            return itm.GetChildren().Count > 0;
        }

        protected abstract void BuildTagContainer(T itm, TagContainer parent);
    }
}
