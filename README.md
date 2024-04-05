## Création d'un compte Admin
1. Créer la table UserAccount **(VIA SSMS)**
2. Créer un compte via le programme **Créer un compte**
3. Via SSMS => `UPDATE UserAccount SET IsAdmin = 1 WHERE Id = 1`


## Ajout du CASCADE sur la table intermédiaire
1. Via SSMS =>
   - `ALTER TABLE Movie_Person DROP CONSTRAINT FK_Movie`
   - `ALTER TABLE Movie_Person ADD CONSTRAINT FK_Movie FOREIGN KEY (MovieId) REFERENCES Movie(Id)`
