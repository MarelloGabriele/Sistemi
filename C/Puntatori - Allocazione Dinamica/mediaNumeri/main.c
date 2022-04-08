#include <stdio.h>

int main() {

    int v[3] = {3,4,5};
    int *p;
    int *i;
    float *pf;
    p = (int*) malloc(sizeof (int)*3);
    pf = (float*) malloc(sizeof (float));
    i = (int*) malloc(sizeof (int));

    pf = 0;
    for(i = 0;i<3;i++){
        pf += p;
    }
    return 0;
}
