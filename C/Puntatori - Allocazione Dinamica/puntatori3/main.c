#include <stdio.h>
#include <stdlib.h>

void stampaVett(int a[],int dim);

int main() {
    int v[] = {1,2,3,4,5};
    int dimV = 5;
    int i;
    stampaVett(v,dimV);

    //allocazione dinamica
    int numElem = 10;
    int *p;
    p = (int*) malloc(sizeof (int)*numElem);

    return 0;
}

void stampaVett(int a[],int dim){
    for (int i = 0; i < dim; i++) {
        printf("%d ",a[i]);
    }
}
