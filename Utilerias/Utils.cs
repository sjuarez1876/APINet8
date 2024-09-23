namespace ApiPersonas.Utilerias
{
    public class Utils
    {
        public static bool validacincuentaCaracteres(string cadena)
        {
            try
            {
                if (cadena.Length > 50)
                {
                    return false;
                }
                else
                {
                    //Ok
                    return true;
                }
            }
            catch
            {
                return false;
            }
           
        }

        public static bool formatoEmail(string email)
        {
            try
            {
                email = email.Trim();
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool solonumeros(string cadena)
        {
            bool resp = false;
            try
            {               
                var negativeString = cadena; //"-123";
                double number;
                if (double.TryParse(negativeString, out number))
                {
                    if (number > 0)
                    {
                        resp = true;
                    }
                    else
                    {
                        //negative number 
                        resp = false;
                    }
                }
            }
            catch {               
                resp = false;           
            }          
            return resp;
        }
    }
}
