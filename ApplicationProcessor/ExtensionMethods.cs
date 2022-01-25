namespace ULaw.ApplicationProcessor
{
    using System;
    using System.ComponentModel;
    using System.Reflection;

    // I would rename this class name like EnumExtensions and move it to a folder like Extensions
    static class ExtensionMethods
    {
        public static string ToDescription(this Enum en)
        {
            Type type = en.GetType();

            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)

            {

                object[] attrs = memInfo[0].GetCustomAttributes(
                                              typeof(DescriptionAttribute),

                                              false);

                if (attrs != null && attrs.Length > 0)

                    return ((DescriptionAttribute)attrs[0]).Description;

            }
            return en.ToString();
        }
    }

}
