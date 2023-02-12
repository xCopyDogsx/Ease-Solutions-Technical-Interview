using System.Collections;
internal class Program
{
    static int Fila=0,Columna=0;
    static int[,] Matriz_Objetos;
    static int Comparador_Mayor=0;
    static int Diferencia_1=0,Diferencia_2=0,Diferencia_3=0;
    static List<Dictionary<string,ArrayList>> Soluciones = new List<Dictionary<string,ArrayList>>();
    static int Contador_Devolucion=0;
    static bool No_Encontro_Solucion = false;
    static ArrayList Recorrido=new ArrayList();
    static int Dimension2D =0;
    private static void Main(string[] args)
    {
        Cargar_Matriz_Archivo();
        for(int i=0;i<4;++i){
            for(int j=0;j<4;++j){
                if(Matriz_Objetos[i,j]>Comparador_Mayor){
                    Comparador_Mayor = Matriz_Objetos[i,j];
                    Fila=i;
                    Columna=j;
                }
            }
        } 
        Dimension2D = Dimension2D-1;   
        Recorrido.Add(Matriz_Objetos[Fila,Columna]);
        Recorrer_Matriz();
        int Resta = 0;
        Console.WriteLine("Recorrido"); 
        foreach(var item in Soluciones){
            foreach(var dato in item){
                if(dato.Key.Equals("Posible solucion")){
                    foreach(var elemento in dato.Value){
                       Console.Write("Nivel: "+elemento.ToString()+", "); 
                       Resta = int.Parse(elemento.ToString())-Resta;
                    }
                }
            }
        }
        Console.WriteLine("\n Profundidad: "+Resta);
    }

    public static void Cargar_Matriz_Archivo(){
       int  Contador_Fila=0,Contador_Columna=0;
       try{
       String Input_File = File.ReadAllText(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "4x4.txt"));
       String[] Splited_File = Input_File.Split("\n");
       String[]  Dimensiones = Splited_File[0].Split(" ");
       Matriz_Objetos  = new int[int.Parse(Dimensiones[0]),int.Parse(Dimensiones[1])];
       Dimension2D=int.Parse(Dimensiones[0]);
        if(Splited_File[1..].Length>int.Parse(Dimensiones[0])){
                throw new Exception($"El archivo tiene {Splited_File[1..].Length-int.Parse(Dimensiones[0])} espacio(s) de demás al final");
            }
            foreach(var fila  in Splited_File[1..] ){
                Contador_Columna = 0;
                foreach(var columna in fila.Split(' ')){
                Matriz_Objetos[Contador_Fila,Contador_Columna] = int.Parse(columna.Trim());
                Contador_Columna++;
                }
                Contador_Fila++;
            }  
         }catch(Exception e){
            throw new Exception("No se pudo cargar la matriz del archivo razon: "+e.Message);
       }   
    }

    public static void Recorrer_Matriz(){ 
        int operacion_1=0,operacion_2=0,operacion_3=0;
        operacion_1=Columna+1;
        operacion_2=Columna-1;
        operacion_3=Fila+1;
        Diferencia_1 = operacion_1<Dimension2D+1?Matriz_Objetos[Fila,Columna]-Matriz_Objetos[Fila,operacion_1]:-1;
        Diferencia_2 = operacion_2<Dimension2D+1&&operacion_2>=0?Matriz_Objetos[Fila,Columna]-Matriz_Objetos[Fila,operacion_2]:-1;
        Diferencia_3 = operacion_3<Dimension2D+1?Matriz_Objetos[Fila,Columna]-Matriz_Objetos[operacion_3,Columna]:-1;
                if(Diferencia_1<(Diferencia_2<0?Diferencia_2*-5:Diferencia_2)&&Diferencia_1<(Diferencia_3<0?Diferencia_3*-5:Diferencia_3)&&Diferencia_1>0)
                {
                    Recorrido.Add(Matriz_Objetos[Fila,Columna+1]);  
                    Columna=Columna+1;
                }else
                if(Diferencia_2<(Diferencia_1<0?Diferencia_1*-5:Diferencia_1)&&Diferencia_2<(Diferencia_3<0?Diferencia_3*-5:Diferencia_3)&&Diferencia_2>0){     
                    Recorrido.Add(Matriz_Objetos[Fila,Columna-1]);      
                    Columna=Columna-1;    
                }else
                if(Diferencia_3<(Diferencia_1<0?Diferencia_1*-5:Diferencia_1)&&Diferencia_3<(Diferencia_2<0?Diferencia_2*-5:Diferencia_2)&&Diferencia_3>0){
                    Recorrido.Add(Matriz_Objetos[Fila+1,Columna]);        
                    Fila=Fila+1;
                }else{  
                   No_Encontro_Solucion=true; 
                }
        if(Fila!=Dimension2D&&!No_Encontro_Solucion){
        Recorrer_Matriz();
        }else{
            Dictionary<string,ArrayList> Respuesta = new Dictionary<string, ArrayList>();
            if(No_Encontro_Solucion){
                Respuesta.Add("No se encontro solucion",Recorrido);
                Soluciones.Add(Respuesta);
            }else{
                Respuesta.Add("Posible solucion",Recorrido);
                Soluciones.Add(Respuesta);
            }  
        }
    }
}