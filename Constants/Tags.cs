using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ASDP.FinalProject.Constants
{
    public static class Tags
    {
        [Display(Name = "ИИН сотрудника")]
        public static string EmployeeIIN = "EmployeeIIN";
        [Display(Name = "ФИО сотрудника")]
        public static string EmployeeFIO = "EmployeeFIO";
        [Display(Name = "Должность сотрудника")]
        public static string EmployeePosition = "EmployeePosition";
        [Display(Name = "Номер документа сотрудника")]
        public static string EmployeeDocumentNumber = "EmployeeDocumentNumber";
        [Display(Name = "Срок действия, кем и когда выдано")]
        public static string ValidityPeriodWhomAndWhenIssued = "ValidityPeriodWhomAndWhenIssued";
        [Display(Name = "ФИО тим лида")]
        public static string TeamLeadFIO = "TeamLeadFIO";
        [Display(Name = "ФИО директора")]
        public static string DirectorFIO = "DirectorFIO";
        [Display(Name = "Текущая дата")]
        public static string Date = "Date";

        public static Dictionary<string,string> AllTags()
        {
            var fields = typeof(Tags)
                .GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);

            Dictionary<string, string> res = new();

            foreach (var field in fields)
            {
                var key = (string) field.GetValue(null)??"";

                var text = field.GetCustomAttributes<DisplayAttribute>().FirstOrDefault()?.Name??"";
                res.Add(key, text);
            }

            return res;
        }
    }
}
