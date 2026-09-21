-- Clubs (6 rows)
INSERT INTO Club (ClubName, City, StadiumName, YearFounded, League) VALUES
('Manchester City', 'Manchester', 'Etihad Stadium', 1880, 'Premier League'),
('Arsenal', 'London', 'Emirates Stadium', 1886, 'Premier League'),
('Chelsea', 'London', 'Stamford Bridge', 1905, 'Premier League'),
('Liverpool', 'Liverpool', 'Anfield', 1892, 'Premier League'),
('Manchester United', 'Manchester', 'Old Trafford', 1878, 'Premier League'),
('Tottenham Hotspur', 'London', 'Tottenham Hotspur Stadium', 1882, 'Premier League');
GO

-- Players (30 rows), 5 per club
INSERT INTO Player (FirstName, LastName, Position, JerseyNumber, Nationality, ClubID) VALUES
('Erling', 'Haaland', 'Forward', 9, 'Norway', 1),
('Enzo', 'Fernandez', 'Midfielder', 8, 'Argentina', 1),
('Elliot', 'Anderson', 'Midfielder', 27, 'England', 1),
('Phil', 'Foden', 'Forward', 47, 'England', 1),
('Josko', 'Gvardiol', 'Defender', 24, 'Croatia', 1),

('Bukayo', 'Saka', 'Forward', 7, 'England', 2),
('Declan', 'Rice', 'Midfielder', 41, 'England', 2),
('Martin', 'Odegaard', 'Midfielder', 8, 'Norway', 2),
('William', 'Saliba', 'Defender', 2, 'France', 2),
('Gabriel', 'Magalhaes', 'Defender', 6, 'Brazil', 2),

('Cole', 'Palmer', 'Midfielder', 10, 'England', 3),
('Joao', 'Pedro', 'Forward', 9, 'Brazil', 3),
('Moises', 'Caicedo', 'Midfielder', 25, 'Ecuador', 3),
('Pedro', 'Neto', 'Forward', 7, 'Portugal', 3),
('Reece', 'James', 'Defender', 24, 'England', 3),

('Alexander', 'Isak', 'Forward', 9, 'Sweden', 4),
('Florian', 'Wirtz', 'Midfielder', 7, 'Germany', 4),
('Hugo', 'Ekitike', 'Forward', 22, 'France', 4),
('Virgil', 'van Dijk', 'Defender', 4, 'Netherlands', 4),
('Alisson', 'Becker', 'Goalkeeper', 1, 'Brazil', 4),

('Bruno', 'Fernandes', 'Midfielder', 8, 'Portugal', 5),
('Benjamin', 'Sesko', 'Forward', 30, 'Slovenia', 5),
('Matheus', 'Cunha', 'Forward', 10, 'Brazil', 5),
('Bryan', 'Mbeumo', 'Forward', 19, 'Cameroon', 5),
('Andrey', 'Santos', 'Midfielder', 27, 'Brazil', 5),

('Sandro', 'Tonali', 'Midfielder', 8, 'Italy', 6),
('Mateus', 'Fernandes', 'Midfielder', 26, 'Portugal', 6),
('Xavi', 'Simons', 'Midfielder', 7, 'Netherlands', 6),
('Mohammed', 'Kudus', 'Forward', 20, 'Ghana', 6),
('Micky', 'van de Ven', 'Defender', 37, 'Netherlands', 6);
GO