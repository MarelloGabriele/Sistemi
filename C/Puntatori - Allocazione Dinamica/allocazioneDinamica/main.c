#include <stdio.h>

void stampaVett(int v[], int len);

int main() {
    int v[] = {1,2,3,4,5};
    int dimV = 5;
    printf("Array statico: \n");
    stampaVett(v,dimV);
    int numElem = 10;
    int *p;
    p = (int *) malloc(sizeof(int) * numElem);
    for(int i=0;i<numElem;i++){
        p[i] = i;
    }
    printf("array dinamico: \n");
    stampaVett(p,numElem);
    p = (int*) calloc(numElem,sizeof (int));
    //funzione di calloc: malloc ma azzera il contenuto
    numElem = 15;

    p = realloc(p, numElem*sizeof (int));
    //funzione di realloc: rialloca il numero di celle necessarie per il vettore
    printf("\nArray dinamico dopo realoc: \n");
    stampaVett(p,numElem);

    free(p);
    return 0;
}


void stampaVett(int v[], int len){
    for(int i=0;i<len;i++){
        printf("%d ", v[i]);
    }
}