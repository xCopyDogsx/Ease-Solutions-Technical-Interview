
internal class Program
{
    static int Fila=0,Columna=0;
    static int[,] Matriz_Objetos = new int[4,4]{{4,8,7,3},
        {2,5,9,3},
        {6,3,2,5},
        {4,4,1,6}};
    static int Comparador_Mayor=0;
    static int Diferencia_1=0,Diferencia_2=0,Diferencia_3=0;
    static List<int> Visitados = new List<int>();
    static int Contador_Devolucion=0;
    static bool Marca_1=false,Marca_2=false,Marca_3=false;
     
    private static void Main(string[] args)
    {
 
        for(int i=0;i<4;++i){
            for(int j=0;j<4;++j){
                if(Matriz_Objetos[i,j]>Comparador_Mayor){
                    Comparador_Mayor = Matriz_Objetos[i,j];
                    Fila=i;
                    Columna=j;
                }
            }
        }
        var rand = new Random();
        // Fila=int.Parse(rand.NextInt64(0,2).ToString());
        // Columna = int.Parse(rand.NextInt64(0,2).ToString());
        Fila=0;
        Columna=1;
        Console.WriteLine(Matriz_Objetos[Fila,Columna]);
      
        Prueba();
       
    }
    public static void Prueba(){
        int operacion_1=0,operacion_2=0,operacion_3=0;
        operacion_1=Columna+1;
        operacion_2=Columna-1;
        operacion_3=Fila+1;
        Diferencia_1 = operacion_1<4?Matriz_Objetos[Fila,Columna]-Matriz_Objetos[Fila,operacion_1]:-1;
        Diferencia_2 = operacion_2<4&&operacion_2>=0?Matriz_Objetos[Fila,Columna]-Matriz_Objetos[Fila,operacion_2]:-1;
        Diferencia_3 = operacion_3<4?Matriz_Objetos[Fila,Columna]-Matriz_Objetos[operacion_3,Columna]:-1;
        Console.WriteLine("--------------");
        Console.WriteLine("Valor posicion: "+Matriz_Objetos[Fila,Columna]);
        Console.WriteLine("Fila: "+Fila);
        Console.WriteLine("Columna: "+Columna);
        Console.WriteLine("Diferencia 1: "+Diferencia_1);
        Console.WriteLine("Diferencia 2: "+Diferencia_2);
        Console.WriteLine("Diferencia 3: "+Diferencia_3);
                
                if(Diferencia_1<(Diferencia_2<0?Diferencia_2*-5:Diferencia_2)&&Diferencia_1<(Diferencia_3<0?Diferencia_3*-5:Diferencia_3)&&Diferencia_1>0&&Visitados.Find(x=>x==Matriz_Objetos[Fila,Columna])!=Matriz_Objetos[Fila,Columna]){
                    Console.WriteLine("Valor: "+Matriz_Objetos[Fila,Columna+1]);
                    Columna=Columna+1;
                    Marca_1=true;
                }else
                if(Diferencia_2<(Diferencia_1<0?Diferencia_1*-5:Diferencia_1)&&Diferencia_2<(Diferencia_3<0?Diferencia_3*-5:Diferencia_3)&&Diferencia_2>0&&Diferencia_1>0&&Visitados.Find(x=>x==Matriz_Objetos[Fila,Columna])!=Matriz_Objetos[Fila,Columna]){     
                    Console.WriteLine("Valor: "+Matriz_Objetos[Fila,Columna-1]);
                    Columna=Columna-1; 
                    Marca_2=true;
                }else
                if(Diferencia_3<(Diferencia_1<0?Diferencia_1*-5:Diferencia_1)&&Diferencia_3<(Diferencia_2<0?Diferencia_2*-5:Diferencia_2)&&Diferencia_3>0&&Diferencia_1>0&&Visitados.Find(x=>x==Matriz_Objetos[Fila,Columna])!=Matriz_Objetos[Fila,Columna]){
                    Console.WriteLine("Valor: "+Matriz_Objetos[Fila+1,Columna]);
                    Fila=Fila+1;
                    Marca_3=true;
                }else{
                    
                    if(Marca_1){
                       Visitados.Add(Matriz_Objetos[Fila,Columna-1]);
                       Console.WriteLine("Me devuelvo de: "+Matriz_Objetos[Fila,Columna]);
                       Columna=Columna-1;
                       Contador_Devolucion++;     
                    }
                    if(Marca_2){
                       Visitados.Add(Matriz_Objetos[Fila,Columna]);
                       Columna=Columna+1;
                       Contador_Devolucion++;     
                    }
                    if(Marca_3){
                        Visitados.Add(Matriz_Objetos[Fila,Columna]);
                        Fila=Fila-1;
                        Contador_Devolucion++;
                    }
                }

        Console.WriteLine("--------------");
        if(Fila!=3&&Contador_Devolucion<3){
        Prueba();
        }
    }
}