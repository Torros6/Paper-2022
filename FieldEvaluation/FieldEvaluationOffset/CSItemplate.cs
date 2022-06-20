using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS.TPS.Common.Model.API;
using System.Text.RegularExpressions;
using IronXL;
using System.Windows.Forms;

namespace FieldEvaluationOffsetAlbin
{
    class CSItemplate
    {
        private OffsetManager _om;
        public OffsetManager CSIOffsetManager { get { return _om; } }

        public CSItemplate(IonPlanSetup m_plan)
        {
            _om = new OffsetManager();
            Offset Field1 = new Offset();
            Offset Field2 = new Offset();
            Offset Field3 = new Offset();
            Field1.OriginalPlanID = m_plan.Id;
            Field2.OriginalPlanID = m_plan.Id;
            Field3.OriginalPlanID = m_plan.Id;
           
            
            foreach (IonBeam beam in m_plan.IonBeams)
            {
               
                if (int.Parse(Regex.Match(beam.Id, @"\d+").Value) == 1)
                    Field1.FieldID = beam.Id;
                if (int.Parse(Regex.Match(beam.Id, @"\d+").Value) == 2)
                    Field2.FieldID = beam.Id;
                if (int.Parse(Regex.Match(beam.Id, @"\d+").Value) == 3)
                    Field3.FieldID = beam.Id;
            }

            IonBeam ionBeam = m_plan.IonBeams.FirstOrDefault(beam => beam.Id.Contains("1"));

            

            Field2.IsoX = Math.Round((ionBeam.IsocenterPosition.x - m_plan.IonBeams.FirstOrDefault(beam => beam.Id.Contains(Field2.FieldID)).IsocenterPosition.x), 1);
            Field2.IsoZ = Math.Round(-(ionBeam.IsocenterPosition.y - m_plan.IonBeams.FirstOrDefault(beam => beam.Id.Contains(Field2.FieldID)).IsocenterPosition.y), 1);
            Field2.IsoY = Math.Round((ionBeam.IsocenterPosition.z - m_plan.IonBeams.FirstOrDefault(beam => beam.Id.Contains(Field2.FieldID)).IsocenterPosition.z), 1);
           
            
           

            Field3.IsoX = Math.Round((ionBeam.IsocenterPosition.x - m_plan.IonBeams.FirstOrDefault(beam => beam.Id.Contains(Field3.FieldID)).IsocenterPosition.x), 1);
            Field3.IsoZ = Math.Round(-(ionBeam.IsocenterPosition.y - m_plan.IonBeams.FirstOrDefault(beam => beam.Id.Contains(Field3.FieldID)).IsocenterPosition.y), 1);
            Field3.IsoY = Math.Round((ionBeam.IsocenterPosition.z - m_plan.IonBeams.FirstOrDefault(beam => beam.Id.Contains(Field3.FieldID)).IsocenterPosition.z), 1);

         
           

            List<double> elements = new List<double>();

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(@"\\SKVfile01.skandion.local\Gemensamdata$\Gemensam\Till-folders and personal folders\Albin K\Från Erik\FieldEvaluation\FieldEvaluationOffset\bin\Debug\Data.txt");
            while (!file.EndOfStream)
            {
                string numb = file.ReadLine();
                string[] numbers = numb.Split('\t'); //This will take the line grabbed from the file and split the string at each space. Then it will add it to the array

                for (int i = 0; i < numbers.Count(); i++)  //loops through each element of the array
                {

                    elements.Add(Math.Round(Convert.ToDouble(numbers[i]), 1)); //Add each word on the array on to woorden list

                }
            }


            for (int j = 0; j<elements.Count;)
            {
               
                Field2.isIsMoved = true;
                Field3.isIsMoved = true;
               
               

                
               


                Field1.x = elements[j];
                Field1.y = elements[j + 1];
                Field1.z = elements[j + 2];
                _om.Add(Field1);

                Field1 = new Offset(Field1);


                j = j + 3;


                Field2.x = elements[j];
                Field2.y = elements[j + 1];
                Field2.z = elements[j + 2];
                _om.Add(Field2);
                _om.addMovedOffset(Field2);

                Field2 = new Offset(Field2);

                j = j + 3;

                Field3.x = elements[j]; 
                Field3.y = elements[j + 1];
                Field3.z = elements[j + 2];
                _om.Add(Field3);
                _om.addMovedOffset(Field3);


                Field3 = new Offset(Field3);


                j = j + 3;

                



               

            }

           
        }
    }
}
