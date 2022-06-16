﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VMS.TPS.Common.Model.API;
using FieldEvaluationOffsetAlbin;

namespace FieldEvaluationOffsetAlbin
{
    public class ValidateAndRun
    {
        public static void Run(PlanSetup plan, Patient patient, Course course)
        {
            if (plan == null)
                MessageBox.Show("Ingen plan vald!", "Check Field Size", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (plan.GetType() != typeof(IonPlanSetup))
                MessageBox.Show("Planen är ej en protonplan!", "Check Field Size", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                FieldEvaluationOffsetAlbin.Form1 form = new Form1((IonPlanSetup)plan, patient);
                form.ShowDialog();
            }
            
                
        }
    }
}
