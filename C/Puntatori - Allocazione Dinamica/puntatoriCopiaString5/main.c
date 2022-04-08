#include <stdio.h>

int main() {
    char s1[20];
    char s2[20];

    printf("Inseirsci Stringa: ");
    scanf("%s",s1);

    char *p1;
    char *p2;

    p1 = s1;
    p2 = s2;

    while (*p1 != '\0')
    {
        *p2 = *p1;
        p1++;
        p2++;
    }
    *p2 = '\0';

    printf("La stringa copiata in S2: %s\n",s2);


    return 0;
}
