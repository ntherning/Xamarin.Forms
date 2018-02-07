using System;

using Xamarin.Forms.CustomAttributes;
using Xamarin.Forms.Internals;
using System.Collections.Generic;

#if UITEST
using Xamarin.UITest;
using NUnit.Framework;
using System.Diagnostics;
#endif

namespace Xamarin.Forms.Controls.Issues
{
	[Preserve (AllMembers = true)]
	[Issue (IssueTracker.Github, 1683, "Auto Capitalization Implementation")]
	public class Issue1683 : ContentPage
	{
		const string kContainerId = "Container";
		public Issue1683()
		{
			var layout = new StackLayout() { ClassId = kContainerId, AutomationId = kContainerId };

			List<InputView> intpuViews = new List<InputView>()
			{
				new Entry() { AutomationId = "EntryNotSet" },
				new Entry() { AutoCapitalization = AutoCapitalization.Characters, AutomationId = "EntryCharacters" },
				new Entry() { AutoCapitalization = AutoCapitalization.None, AutomationId = "EntryNone" },
				new Entry() { AutoCapitalization = AutoCapitalization.Sentences, AutomationId = "EntrySentences" },
				new Entry() { AutoCapitalization = AutoCapitalization.Words, AutomationId = "EntryWords" },
				new Editor() { AutomationId = "EditorNotSet" },
				new Editor() { AutoCapitalization = AutoCapitalization.Characters, AutomationId = "EditorCharacters" },
				new Editor() { AutoCapitalization = AutoCapitalization.None, AutomationId = "EditorNone" },
				new Editor() { AutoCapitalization = AutoCapitalization.Sentences, AutomationId = "EditorSentences" },
				new Editor() { AutoCapitalization = AutoCapitalization.Words, AutomationId = "EditorWords" }
			};


			foreach(InputView child in intpuViews)
			{
				var inputs = new StackLayout()
				{
					Orientation =  StackOrientation.Horizontal
				};

				if(child is Entry)
					(child as Entry).Text = "I am. The Text. of the Pants.";

				if(child is Editor)
					(child as Editor).Text = "I am. The Text. of the Pants.";


				child.HorizontalOptions = LayoutOptions.FillAndExpand;
				inputs.Children.Add(new Label() { Text = child.AutomationId });
				inputs.Children.Add(child);
				layout.Children.Add(inputs);
			}

			Content = layout;
		}

//#if UITEST
//		[Test]
//		[Ignore("Auto Capitalization only works when interacting directly with the keyboard")]
//		public void Issue1683Test ()
//		{
//			var container = RunningApp.Query(c => c.Marked(kContainerId).Child());

//			foreach (var inputView in container)
//			{
//				string automationId = inputView.Label.Split('_')[0];

//				RunningApp.EnterText(automationId, "i am a sentence. are you? yes! o.k.");
//				var textResult = RunningApp.Query(c => c.Marked(automationId))[0].Text;

//				switch (automationId)
//				{
//					case "EntryCharacters":
//						Assert.AreEqual("I AM A SENTENCE. ARE YOU? YES! O.K.", textResult);
//						break;
//				}
//			}	
//		}
//#endif
	}
}
