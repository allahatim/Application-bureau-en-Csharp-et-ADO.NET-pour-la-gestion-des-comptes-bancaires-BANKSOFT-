# Application-bureau-en-Csharp-et-ADO.NET-pour-la-gestion-des-comptes-bancaires-BANKSOFT-

L'application bureau de gestion des comptes bancaires en C#(BANKSOFT) est un outil de travail pour les agents de la banque, qui leur permet de gérer les comptes de leurs clients. L'interface utilisateur, développée avec le Bunifu Framework, est conviviale et moderne. SAP Crystal Report est utilisé pour la génération de rapports, tandis que ADO.NET est utilisé pour la gestion des données
L'application contient 6 formulaires.

-Le premier formulaire est le formulaire de connexion. Si l'utilisateur entre des informations de connexion valides, il sera redirigé vers la page d'accueil. Sinon, il recevra un message d'erreur.!

![image](https://user-images.githubusercontent.com/125883841/228402932-9c1a09e2-dfd5-4500-aab0-76400766ca5d.png)

-La page d'accueil contient quatre boutons, chacun d'eux dirige l'agent vers l'un des formulaires disponibles. Ces boutons sont conçus pour faciliter la navigation entre les différentes fonctionnalités de l'application.Le premier bouton, "Gestion des comptes clients", redirige l'agent vers le formulaire de gestion des comptes clients.Le deuxième bouton, "Transactions", redirige l'agent vers le formulaire de transactions.Le troisième bouton, "Extrait de compte", redirige l'agent vers le formulaire d'extrait de compte.Le quatrième bouton, "Rapport journalier", redirige l'agent vers le formulaire de rapport journalier![image](https://user-images.githubusercontent.com/125883841/228403215-9cbec7d1-d5cb-4d67-b071-a57c58577623.png)
-Le formulaire de gestion des comptes clients permet à l'agent d'ajouter, de modifier et de supprimer des clients de la banque. Les informations de base du client, telles que Titulaire de compte, Cin, téléphone, solde.
On a développer une méthode " Generatenumber() " pour générer un numéro de compte bancaire de 12 caractères lorsqu'un nouveau client est ajouté. Une autre méthode nommée "Ifexistnumber()" est également mise en place pour vérifier si le numéro généré existe déjà dans la base de données. Si tel est le cas, la méthode "Generatenumber()" génère un nouveau numéro jusqu'à ce qu'un numéro unique soit créé. Si le numéro n'existe pas déjà dans la base de données, l'insertion du nouveau client est effectuée avec succès.
![image](https://user-images.githubusercontent.com/125883841/228403251-87054a8b-36ce-42f7-b1bc-c66ba6976938.png)

-Le formulaire de transaction permet à l'agent de déposer ou de retirer de l'argent d'un compte bancaire pour un client donné. Il doit saisir le numéro de compte du client et le montant de la transaction.![image](https://user-images.githubusercontent.com/125883841/228403276-35f3530b-c2f2-44e7-ae39-0fdc76302c53.png)

-Le formulaire d'extrait de compte permet à l'agent de générer un extrait de compte pour un compte bancaire donné. Il doit saisir le numéro de compte et les dates de début et de fin de la période souhaitée. Les informations seront affichées sur l'écran et l'agent peut imprimer l'extrait de compte
![image](https://user-images.githubusercontent.com/125883841/228403306-9bd82029-7ef3-4cbf-8a43-380f7e4a8523.png)

-Le formulaire de rapport journalier permet à l'agent de générer une liste des transactions effectuées par lui-même pour une journée donnée. Il peut également effectuer une recherche de transactions entre deux dates et imprimer les informations.![image](https://user-images.githubusercontent.com/125883841/228403357-3b857c7a-f493-4ee6-8c55-9183951f2286.png)
