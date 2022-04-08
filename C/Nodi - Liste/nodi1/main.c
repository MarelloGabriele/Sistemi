#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct studente{
    int codice;
    char cognome[20];
    float media;
    struct studente *next;
}Studente;

Studente* addOnHead(Studente *testa, int *prog); //Aggiungo nuovo nodo in testa alla lista
Studente* addOnTail(Studente *head, int *prog);
Studente* nuovoStudente(int *prog);
int contaNodi(Studente *testa);
Studente* addByPos(Studente *testa, int *prog,int posizione);
void showList(Studente *head);


int main()
{
    int progStu = 0; //Progressivo Codice Studente
    Studente *testa = NULL; //Puntatore al primo nodo
    int scelta;
    int pos;
    do {
        printf("Menu: \n");
        printf("1. Aggiungi Nodo in Testa\n");
        printf("2. Aggiungi Nodo in Coda\n");
        printf("3. Stampa lista\n");
        printf("4. Conta Nodi lista\n");
        printf("5. Aggiungi nodo alla posizione inserita\n");
        printf("0. Esci\n");
        printf("Scelta: ");
        scanf("%d",&scelta);
        switch (scelta) {
            case 1:
                testa = addOnHead(testa, &progStu); //Aggiungo nuovo nodo in testa alla lista
                break;
            case 2:
                testa = addOnTail(testa, &progStu);
                break;
            case 3:
                showList(testa);
                break;
            case 4:
                printf("La lista presenta %d nodi\n",contaNodi(testa));
                break;
            case 5:
                printf("Inserire la posizione in cui inserire il nuovo nodo: ");
                scanf("%d",&pos);
                testa = addByPos(testa,&progStu,pos);

        }
    } while (scelta != 0);

    return 0;
}
void showList(Studente *head){
    Studente *pLista;
    if(head == NULL)
        printf("Lista Vuota\n");
    else
    {
        pLista = head;
        printf("Lista Studenti\n");
        printf("\nCodice\tCognome\t\tMedia");
        do{
            printf("\n%d\t%s\t\t%f\n", pLista->codice, pLista ->cognome, pLista->media);
            pLista = pLista->next;
        }
        while(pLista != NULL);
    }

}
Studente* addOnHead(Studente *head, int *prog){
    Studente *pStu; //Puntatore al nuovo nodo
    pStu = nuovoStudente(prog);
    pStu ->next = head;
    return pStu;
}

Studente* addOnTail(Studente *head, int *prog){
    Studente *pLista;
    Studente *pStu;
    pStu = nuovoStudente(prog);

    if(head == NULL)
        head =  pStu;
    else
    {
        pLista = head;
        while (pLista->next != NULL)
            pLista = pLista->next;
        pLista -> next = pStu;
    }
    return head;

    pLista = head;
    while (pLista->next != NULL)
        pLista = pLista -> next;
    pLista -> next = pStu;
}
Studente* nuovoStudente(int* prog){
    int cod;
    char cogn[20];
    float med;
    Studente *pNew;


    (*prog)++;
    printf("Nuovo Studente: \n");
    printf("Inserisce Cognome: ");
    scanf("%s",cogn);
    do {
        printf("Inserisci Media: ");
        scanf("%f",&med);
    } while (med < 2 || med > 10);

    pNew = (Studente*) malloc(sizeof (Studente));
    pNew -> codice = *prog;
    strcpy(pNew -> cognome,cogn);
    pNew -> media = med;
    pNew -> next = NULL;

    return pNew;
}
int contaNodi(Studente *head){
    Studente *pLista;
    int cont =0;
    if(head == NULL)
        cont =0;
    else
    {
        pLista = head;
        while (pLista->next != NULL){
            cont++;
            pLista = pLista->next;
        }
        cont++;
    }
    return cont;
}
Studente* addByPos(Studente *head, int *prog,int posizione)
{
    Studente *pLista;
    Studente *pStu;
    Studente *forwardedNext;
    pStu = nuovoStudente(prog);

    if(head == NULL){
        pStu ->next = head;
        return pStu;
    }
    else
    {
        pLista = head;
        int i=0;
        while (pLista->next != NULL && i<posizione-1)
            pLista = pLista->next;
        forwardedNext = pLista -> next;
        pLista -> next = pStu;
        pStu -> next = forwardedNext;
    }
    return head;

}