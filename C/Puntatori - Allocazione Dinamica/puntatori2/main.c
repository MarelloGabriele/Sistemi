#include <stdio.h>

int main() {
    int a[] ={10,34,62};
    int i;
    for(int i=0;i<3;i++){
        printf("a[%d]: %d\t%p\n",i,a[i],&a[i]);
    }

    printf("Indirizzo con indice: %p\t Indirizzo con puntatore: %p\n",&a[1],a+1);

    int *pa = &a[0];
    printf("Indirizzo puntatore : %p\t%d\n",pa,*(pa+1));

    return 0;
}
