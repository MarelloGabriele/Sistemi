#include <stdio.h>
#include <stdlib.h>
#define LENSTR 100

int lenstr(char*);
void uppercase(char*);
char* concat(char* , char*);
void sort(char*);

int main( )
{
    int *menu;
    int *len;
    char *s;
    char *s2;
    char *sConcatenata;
    s2 = (char*)malloc(sizeof(char)*LENSTR);
    s= (char*) malloc(sizeof(char)*LENSTR);
    sConcatenata = (char*)malloc(sizeof(char)*LENSTR);

    menu = (int*)malloc(sizeof(int));
    len = (int*)malloc(sizeof(int));

    printf("Inserire la stringa: ");
    scanf("%s", s);
    printf("\n");
    printf("1: Calcola lunghezza Stringa - lenstr(s)");
    printf("\n");
    printf("2: Modifica una stringa sostituendo le lettere minuscole con lettere maiuscole - uppercase(s,s1)");
    printf("\n");
    printf("3: Concatena due stringhe  - concat(s)");
    printf("\n");
    printf("4: Ordina i caratteri di una stringa - sort(s)");
    printf("\n");
    printf("0: Esci");
    printf("\n");

    do
    {
        printf("Inserire il numero corrispondente alla funzione da usare:  ");
        scanf("%d", &*menu);
    }
    while(*menu<0 || *menu>4);

    switch (*menu) {
        case 1:
            *len = lenstr(s);
            printf("La lunghezza della stringa inserita e' di: %d",*len);
            free(len);
            break;
        case 2:
            uppercase(s);
            printf("La stringa s vale: %s",s);
            break;
        case 3:
            printf("\n\nInserire una seconda stringa: ");
            scanf("%s", s2);
            sConcatenata = concat(s,s2);
            printf("\nLa stringa Concatenata vale: %s",sConcatenata);
            break;
        case 4:
            sort(s);
            printf("\nLa stringa Ordinata vale: %s",s);
            break;
        case 0:
            return 0;

    }

    return 0;
}

int lenstr(char* s) {
    int *cont;
    cont = (int*)malloc(sizeof(int));
    *cont = 0;

    while(*(s+(*cont))!=0x00){
        (*cont)++;
    }

    return (*cont);

}

void uppercase(char* s) {
    int *i;
    i= (int*)malloc(sizeof(int));
    *i=0;
    while( *(s+(*i))!=0x00){
        if(*(s+(*i))>='a' && *(s+(*i))<='z')
            *(s+(*i))-=32;
        (*i)++;
    }

    free(i);
}

char* concat(char* s1, char*s2) {
    char *sConc;
    int *i;
    int *cont;

    i = (int*)malloc(sizeof(int));
    cont =(int*)malloc(sizeof(int));

    *cont = lenstr(s1);
    *cont += lenstr(s2);

    sConc = (char*)malloc(sizeof(char)* ((*cont)+1));
    printf("\n%d",sizeof(char)* ((*cont)+1));


    *i = 0;
    while(*(s1+(*i))!=0x00){
        *sConc=*(s1+(*i));
        (*i)++;
        printf("test");
    }
    while (*(s2+(*i))!=0x00){
        *sConc=*(s2+(*i));
        (*i)++;
    }

    *sConc=0x00;
    sConc=sConc-(*cont);
    free(cont);
    free(i);

    return sConc;
}


void sort(char* s) {
    int *posmin;
    char *aus;

    posmin = (int*)malloc(sizeof(int));
    aus = (char*)malloc(sizeof(char));

    int *i, *j;
    i = (int*)malloc(sizeof(int));
    j = (int*)malloc(sizeof(int));
    for(*i = 0; *(s + (*i) + 1)!=0x00; (*i)++)
    {
        *posmin = *i;
        for(*j = (*i) + 1; *(s + (*j))!=0x00; (*j)++)
            if(*(s + (*j)) < *(s + (*posmin)))
                *posmin = *j;
        if(*posmin != *i)
        {
            *aus = *(s + (*i));
            *(s + (*i)) = *(s + (*posmin));
            *(s + (*posmin)) = *aus;
        }
    }

    free(i);
    free(j);
    free(posmin);
    free(aus);
}