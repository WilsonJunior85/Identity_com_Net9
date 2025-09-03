namespace Identity_com_Net9.Models
{
    public class ResultModel<T>
    {
        public T? Data { get; set; }

        public string Mensagem { get; set; } = string.Empty;

        public bool Status { get; set; } = true;
    }
}
