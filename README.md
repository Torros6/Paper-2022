# Paper-2022
This is a scrip were manual or predecided shifts to a treatment plan can be applied.

To run this script download the folder "FieldEvaluation" and open the "FieldEvaluationOffsetAlbin.csproj" file in example microsoft visual studio to build the script. After the scrip is build it needs to be approved in the TPS Eclipse, lastly the plan that are going to be used needs to be adjusted to fit the scrip. Only three fields can be used in its current state and needs to be separeate into three field groups. 


Changes made by Albin Karlsson 

TbaPopup.cs: row 45-46 closing popup windows so that the program doesn't stop runing.
  
CSItemplate.cs: row 21-40 create objects and assign the treatmentfields from Eclipse to them, row 58-119 creates a list that reads in offsets from a txt file and moves the fields accordingly.  

Form1.cs: row 60-77 Fixed the progress bar and the naming of the plans created, row 106 fixed the time estimation for the calulations. 
