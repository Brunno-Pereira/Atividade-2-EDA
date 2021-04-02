using System;

// Custo: O(N), sendo N o numero de itens na arvore binaria

namespace Prova2EDA {

    class Node {
        public Node esq = null, dir = null;
        public int num = 0;
    }

    class ArvoreBinaria {
        public Node raiz;

        public bool add(int numero) {
            Node esquerda = null, direita = raiz;

            while (direita != null) {
                esquerda = direita;
                if (numero < direita.num) {
                    direita = direita.esq;
                } else if (numero > direita.num) {
                    direita = direita.dir;
                } else {
                    return false;
                }
            }

            Node aux = new Node();
            aux.num = numero;

            if (raiz == null) {
                raiz = aux;
            } else {
                if (numero < esquerda.num) {
                    esquerda.esq = aux;
                } else {
                    esquerda.dir = aux;
                }   
            }

            return true;
        }

        public Node Procurar(int value) {
            return Procurar(value, raiz);
        }

        public void Remover(int value) {
            raiz = Remover(raiz, value);
        }

        public Node Remover(Node raiz, int key) {
            if (raiz == null) return raiz;

            if (key < raiz.num) {
                raiz.esq = Remover(raiz.esq, key);
            }else if (key > raiz.num) {
                raiz.dir = Remover(raiz.dir, key);
            } else {
                if (raiz.esq == null)
                    return raiz.dir;
                else if (raiz.dir == null)
                    return raiz.esq;

                raiz.num = menorValor(raiz.dir);

                raiz.dir = Remover(raiz.dir, raiz.num);
            }

            return raiz;
        }

        int menorValor(Node node) {
            int minValor = node.num;

            while (node.esq != null) {
                minValor = node.esq.num;
                node = node.esq;
            }

            return minValor;
        }

        Node Procurar(int value, Node parent) {
            if (parent != null) {
                if (value == parent.num) return parent;
                if (value < parent.num)
                    return Procurar(value, parent.esq);
                else
                    return Procurar(value, parent.dir);
            }

            return null;
        }

        public int Profundidade() {
            return this.Profundidade(raiz);
        }

        int Profundidade(Node parent) {
            if (parent == null) {
                return 0;
            } else {
                return Math.Max(Profundidade(parent.esq), Profundidade(parent.dir)) + 1;
            }
        }

        public void preOrdem(Node raiz) {
            if (raiz != null) {
                Console.Write(raiz.num + " ");
                preOrdem(raiz.esq);
                preOrdem(raiz.dir);
            }
        }

        public void Ordem(Node raiz) {
            if (raiz != null) {
                Ordem(raiz.esq);
                Console.Write(raiz.num + " ");
                Ordem(raiz.dir);
            }
        }

        public void PosOrdem(Node parent) {
            if (parent != null) {
                PosOrdem(parent.esq);
                PosOrdem(parent.dir);
                Console.Write(parent.num + " ");
            }
        }

        public static void Main(String[] args) {
            ArvoreBinaria arvoreBinaria = new ArvoreBinaria();

            int[] x = new int[] { 8, 54, 19, 68, 5, 4, 106, 38, 5, 4, 79, 8 };
            foreach(int num in x){
                arvoreBinaria.add(num);
            }

            Node node = arvoreBinaria.Procurar(5);
            int profund = arvoreBinaria.Profundidade();

            Console.WriteLine("PreOrdem: ");
            arvoreBinaria.preOrdem(arvoreBinaria.raiz);
            Console.WriteLine();

            Console.WriteLine("Ordem: ");
            arvoreBinaria.Ordem(arvoreBinaria.raiz);
            Console.WriteLine();

            Console.WriteLine("PosOrdem: ");
            arvoreBinaria.PosOrdem(arvoreBinaria.raiz);
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}