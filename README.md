# TPServiceWebSOAP

L’objectif de ce TP est de développer en C# une application de réservation d’hôtels en ligne
Cette application propose une interface permettant à un utilisateur de saisir les informations
suivantes : Une ville de séjour, une date d’arrivée, une date de départ, un intervalle de prix
souhaité, une catégorie d’hôtel : nombre d’étoiles, le nombre de personnes à héberger.
En réponse, l’application lui retourne une liste d’hôtels qui répondent à ses critères et où pour
chaque hôtel les informations suivantes sont affichées : nom de l’hôtel, adresse de l’hôtel
(pays, ville, rue, numéro, lieu-dit, position GPS), le prix à payer, nombre d’étoile, nombre de
lits proposés.
L’utilisateur choisira un hôtel dans la liste proposée et l’application lui demandera les
informations suivantes : le nom et prénom de la personne principale à héberger, les
informations de la carte de crédit de paiement. L’application utilisera ces informations pour
réaliser la réservation de l’hôtel en question.

* Chaque hôtel aura son propre serveur et ainsi ses propres services web pour
pouvoir :
    * Service web 1 : Consulter les disponibilités par les agences partenaires
    où :
    * Les données en entrée du service web concernent :
    * Identifiant et mot de passe de l’agence.
    * Dates début et fin de la réservation.
    * Nombre de personnes à héberger.
    • Les données en réponse du service web :
    * Une liste d’offres où une offre est caractérisée par :
        * Un Identifiant de l’offre.
        * Type de chambre : nombre de lits.
        * Date de disponibilité.
        * Prix.

   * Service web 2 : Effectuer une réservation où :
   * Les données en entrée du service web concernent :
   * Identifiant de l’agence.
   * Login.
   * Mot de passe.
   * Identifiant de l’offre.
   * Informations personne principale.
   * Les données en réponse du service web :
   * Confirmation de la réservation ou problème.
   * Référence de la réservation si cette dernière est
    confirmée.
