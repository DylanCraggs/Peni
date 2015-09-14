using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace Peni
{

	public class MenuListData : List<MenuItem>
	{
		public MenuListData ()
		{
			this.Add (new MenuItem () { 
				Title = "Home", 
				IconSource = "ic_home_white_48dp.png", 
				TargetType = typeof(PeniMainContet)
			});

			this.Add (new MenuItem () { 
				Title = "Health", 
				IconSource = "ic_favorite_white_48dp.png", 
				TargetType = typeof(DummyPage)
			});

			this.Add (new MenuItem () { 
				Title = "Forum", 
				IconSource = "ic_question_answer_white_48dp.png", 
				TargetType = typeof(DummyPage)
			});

            this.Add(new MenuItem()
            {
                Title = "Resources",
                IconSource = "ic_local_library_white_48dp.png",
                TargetType = typeof(DummyPage)
            });

            this.Add(new MenuItem()
            {
                Title = "Logout",
                IconSource = "ic_power_settings_new_white_48dp.png",
                TargetType = typeof(DummyPage)
            });

        }
	}
}