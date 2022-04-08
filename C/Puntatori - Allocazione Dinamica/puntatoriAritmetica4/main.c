#include <stdio.h>

int main() {
    /*
     * Sostituire i caratteri presenti nel vettore c
     * con 'H' 'E' 'L' 'L' 'O'
     * */
    char c[6] = {'S','A','L','V','E','\0'};

    char *p;
    p = c;
    printf("Prima strina: \n");
    while (*p != '\0')
    {
        printf("%c",*p);
        p++;
    }

    p = c;
    *(p++) = 'H';
    *(p++)  = 'E';
    *(p++)  = 'L';
    *(p++)  = 'L';
    *(p++)  = 'O';

    /* è possibile anche
     *
    *p = 'H';
    *(++p)  = 'E';
    *(++p)  = 'L';
    *(++p)  = 'L';
    *(++p)  = 'O';
    */

    p = &c[0];
    printf("\nPrima strina: \n");
    while (*p != '\0')
    {
        printf("%c",*p);
        p++;
    }
    return 0;
}
