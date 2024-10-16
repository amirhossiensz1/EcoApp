#region Note

/*
{**************************************************************************************************************}
{  This file is automatically created when you open the Scheduler Control smart tag                            }
{  *and click Create Customizable Appointment Dialog.                                                          }
{  It contains a a descendant of the default appointment editing form created by visual inheritance.           }
{  In Visual Studio Designer add an editor that is required to edit your appointment custom field.             }
{  Modify the LoadFormData method to get data from a custom field and fill your editor with data.              }
{  Modify the SaveFormData method to retrieve data from the editor and set the appointment custom field value. }
{  The code that displays this form is automatically inserted                                                  }
{  *in the EditAppointmentFormShowing event handler of the SchedulerControl.                                   }
{                                                                                                              }
{**************************************************************************************************************}
*/

#endregion Note

using System;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.UI;

namespace Eco
{
    public partial class CustomAppointmentForm : AppointmentForm
    {
        public CustomAppointmentForm()
        {
            InitializeComponent();
        }

        public CustomAppointmentForm(SchedulerControl control, Appointment apt)
            : base(control, apt)
        {
            InitializeComponent();
        }

        public CustomAppointmentForm(SchedulerControl control, Appointment apt, bool openRecurrenceForm)
            : base(control, apt, openRecurrenceForm)
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Add your code to obtain a custom field value and fill the editor with data.
        /// </summary>
        public override void LoadFormData(Appointment appointment)
        {
            base.LoadFormData(appointment);
        }

        /// <summary>
        ///     Add your code to retrieve a value from the editor and set the custom appointment field.
        /// </summary>
        public override bool SaveFormData(Appointment appointment)
        {
            return base.SaveFormData(appointment);
        }

        /// <summary>
        ///     Add your code to notify that any custom field is changed. Return true if a custom field is changed, otherwise
        ///     false.
        /// </summary>
        public override bool IsAppointmentChanged(Appointment appointment)
        {
            return false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
        }
    }
}