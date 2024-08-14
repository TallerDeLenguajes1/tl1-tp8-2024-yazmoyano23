namespace espacioTarea
{
    public class Tarea
    {

        private int tareaID;
        private string descripcion;
        private int duracion;

        public int Duracion { get => duracion; set => duracion = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int TareaID { get => tareaID; set => tareaID = value; }

        public Tarea(){}
        public Tarea( int id, string descripcion, int duracion){ //Recibe los paraaametros y los construye
            TareaID = id;
            Descripcion = descripcion;
            Duracion = duracion;
        }
    }

}