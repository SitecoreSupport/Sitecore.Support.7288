using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Mvc.Pipelines.Response.GetXmlBasedLayoutDefinition;
using Sitecore.Mvc.Presentation;
using Sitecore.XA.Feature.StickyNotes;
using Sitecore.XA.Foundation.SitecoreExtensions.Extensions;

namespace Sitecore.Support.XA.Feature.StickyNotes.Pipelines.GetXmlBasedLayoutDefinition
{
    public class AddStickyNotesRendering:Sitecore.XA.Feature.StickyNotes.Pipelines.GetXmlBasedLayoutDefinition.AddStickyNotesRendering
    {
        public override void Process(GetXmlBasedLayoutDefinitionArgs args)
        {
            Item item = args.ContextItem ?? PageContext.Current.Item;
            if (item == null)
            {
                return;
            }
            if (item.InheritsFrom(Templates._StickyNote.ID) && !Sitecore.Context.PageMode.IsExperienceEditor)
            {
                return;
            }             
            if (item.InheritsFrom(Templates._StickyNote.ID))
            {
                this.AddRendering(args, item);
            }
        }

      
    }
}