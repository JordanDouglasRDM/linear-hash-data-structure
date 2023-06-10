const int N = 5;

int Hash(int chave)
{
   return (chave % N);
}

void InsereLinear(Aluno[] v, int nt, string nm, string em, ref int colisao)
{
   int pos = Hash(nt);
   
   while (v[pos]  != null) {
      pos++;
      pos = pos % N;
      colisao++;
   }
   Aluno novoAluno = new Aluno();
   novoAluno.Nota = nt;
   novoAluno.Nome = nm;
   novoAluno.Email = em;
   v[pos] = novoAluno;
   System.Console.WriteLine("Aluno cadastrado com sucesso!");
   Console.ReadKey();
}

void Recuperar(Aluno[] v, int c)//c == chave == nota
{
   int pos = Hash(c);
   while (v[pos] != null) {
      if(v[pos].Nota == c) {//inicia busca exautiva
         System.Console.WriteLine($"Nota do aluno: {v[pos].Nota}");
         System.Console.WriteLine($"Nome do aluno: {v[pos].Nome}");
         System.Console.WriteLine($"Email do aluno: {v[pos].Email}");
         Console.ReadKey();
         return;//se encontrou retorna
      }
      pos++;
      pos = pos % N;
   }
   System.Console.WriteLine("Aluno não encontrado.");
   Console.ReadKey();
}

Aluno[] vetor = new Aluno[N];
int colisao = 0;

int menu()
{
    Console.Clear();
    System.Console.WriteLine("###### Menu ######");
    System.Console.WriteLine("1 - Inserir");
    System.Console.WriteLine("2 - Recuperar");
    System.Console.WriteLine("3 - Informar");
    System.Console.WriteLine("4 - Sair");
    System.Console.WriteLine("____________________");
    System.Console.WriteLine("Informe a opção desejada: ");
    int opc = Convert.ToInt32(Console.ReadLine());
    return opc;
}

int opcao = 0;
while (opcao != 4) {
    Console.Clear();
    opcao = menu();
    if (opcao == 1) {
        System.Console.Write("Digite a nota: ");
        int nota = Convert.ToInt32(Console.ReadLine());
        System.Console.Write("Digite o nome: ");
        string nome = Console.ReadLine() ?? "";//coalescência nula (se nulo, atribui um valor padrao) usado só para remover o warning do c#
        System.Console.Write("Digite o email: ");
        string email = Console.ReadLine() ?? "";
        InsereLinear(vetor, nota, nome, email, ref colisao);
    }else if(opcao == 2) {
         System.Console.Write("Digite uma nota para pesquisar: ");
         int valorBuscado = Convert.ToInt32(Console.ReadLine());
         Recuperar(vetor, valorBuscado);
      }else if(opcao == 3) {
         System.Console.Write($"Até o momento temos {colisao} colisões.");
         Console.ReadKey();
      }
}
class Aluno
{
    public int Nota = 0;
    public string Nome = "";
    public string Email = "";
}