#include <stdio.h>

int main() {
    int i=10;
    char c = 'a';
    int *pi;
    char *pc;

    printf("i: %d - c: %c",i,c);
    printf("\n");
    printf("Char %d Byte, Int %d Byte\n",sizeof (char), sizeof (int));
    printf("Puntatore char %d Byte - Puntatore Int %d Byte \n",sizeof(char*),sizeof (int*));

    pi = &i;
    pc = &c;

    /* STAMPA DEGLI INDIRIZZI DEI PUNTATORI */

    /* STAMPA DEGLI INDIRIZZI DEI PUNTATORI */
    printf("Indirizzo del puntatore i: %p - Indirizzo del puntatore c: %p\n",&pi,&pc);
    /* STAMPA DEGLI INDIRIZZI DEI PUNTATORI CHE REFERNZIANO LA CELLA PUNTATA */
    printf("Indirizzo di memoria di i: %p - Indirizzo di memoria di c: %p\n",pi,pc);

    printf("Il valore di i: %d - Il valore della cella puntata da pi: %d\n",i,*pi);
    /* MODIFICA CONTENUTO PUNTATORE */
    *pi = i+25;
    printf("Il valore di i: %d - il valore della cella puntata da pi: %d\n",i,*pi);


    return 0;
}
