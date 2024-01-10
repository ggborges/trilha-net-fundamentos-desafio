using System.Runtime.InteropServices;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        // Verificação de placa válida (AAA-0000)
        public bool PlacaValida(string placa)
        {
            bool valida = true;
            
            if(placa.Contains('-') && placa.Length == 8)
            {
                // Divide entre a parte alfabética e parte numérica
                string[] partesDaPlaca = placa.Split('-');
                for(int i = 0; i < partesDaPlaca.Length; i++)
                {
                    string parte = partesDaPlaca[i];
                    foreach(char caracter in parte)
                    {
                        if(i == 0 && !char.IsLetter(caracter)) // Para i=0 => parte alfabética
                        {
                            valida = false;
                            break;
                        } else if(i == 1 && !char.IsDigit(caracter)) // Para i=1 => parte numérica
                        {
                            valida = false;
                            break;
                        }
                    }
                }
            } else
            {
                valida = false;
            }

            return valida;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placaVeiculo = Console.ReadLine().ToUpper();
            
            if(veiculos.Contains(placaVeiculo))
            {
                Console.WriteLine("Carro já estacionado.");
                return;
            }

            if(PlacaValida(placaVeiculo))
            {
                veiculos.Add(placaVeiculo);
            } else
            {
                Console.WriteLine("Placa cadastrada não é uma placa válida.\n(Ex: AAA-0000)");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            string placaVeiculo = Console.ReadLine().ToUpper();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placaVeiculo.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = int.Parse(Console.ReadLine());
                decimal valorTotal = precoInicial + (precoPorHora * horas); 

                // Remover a placa digitada da lista de veículos
                veiculos.Remove(placaVeiculo);

                Console.WriteLine($"O veículo {placaVeiculo} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo.ToUpper());
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
