using System;
using System.Collections.Generic;
using System.Text;

namespace EWalletAdminApp.Functions
{
	public class TimeHello
	{
		public string HelloAgrent { get; set; }
		public TimeHello()
		{
			HelloAgrent = HelloWorld(DateTime.Now);

		  }
		public string HelloWorld(DateTime time)
		{
			string detail = "สวัสดีจร้า";
			DateTime moningstart = DateTime.Parse("5:00:00 AM");
			DateTime moningEnd = DateTime.Parse("11:59:00 AM");
			DateTime lunchstart = DateTime.Parse("11:59:00 AM");
			DateTime lunchEnd = DateTime.Parse("1:00:00 PM");
			DateTime Bstart = DateTime.Parse("1:00:00 AM"); //ตอนแบ่าย
			DateTime BEnd = DateTime.Parse("3:45:00 PM");//ตอนบ่าย
			DateTime Estart = DateTime.Parse("3:45:00 PM"); //ตอนเย็น
			DateTime EEnd = DateTime.Parse("6:45:00 PM");//ตอนเย็น
			DateTime Nstart = DateTime.Parse("6:45:00 PM"); //ตอนมืด
			DateTime NEnd = DateTime.Parse("9:45:00 PM");//ตอนมืด

			if ((time.TimeOfDay > moningstart.TimeOfDay)&& (time.TimeOfDay <= moningEnd.TimeOfDay))
			{
				detail = "สวัสดีตอนเช้า";
			}
			else if ((time.TimeOfDay > lunchstart.TimeOfDay) && (time.TimeOfDay <= lunchEnd.TimeOfDay))
			{
				detail = "สวัสดีตอนเที่ยง";
			}
			else if ((time.TimeOfDay > Bstart.TimeOfDay) && (time.TimeOfDay <= BEnd.TimeOfDay))
			{
				detail = "สวัสดีตอนบ่าย";
			}
			else if ((time.TimeOfDay > Estart.TimeOfDay) && (time.TimeOfDay <= EEnd.TimeOfDay))
			{
				detail = "สวัสดีตอนเย็น";
			}
			else if ((time.TimeOfDay > Nstart.TimeOfDay) && (time.TimeOfDay <= NEnd.TimeOfDay))
			{
				detail = "สวัสดีตอนมืด";
			}
			return detail;
         }
	}
}
