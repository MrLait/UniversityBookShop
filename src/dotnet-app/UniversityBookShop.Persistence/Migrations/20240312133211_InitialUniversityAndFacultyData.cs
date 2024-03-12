using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniversityBookShop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialUniversityAndFacultyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "currency_code_id", "Description", "Name", "total_book_price" },
                values: new object[,]
                {
                    { 1, 1, "A leading institution dedicated to excellence in education and research.", "Starlight University", null },
                    { 2, 1, "Empowering the future through cutting-edge technology and innovation.", "Galactic Institute of Technology", null },
                    { 3, 1, "Nurturing creativity and talent in the fields of arts and humanities.", "Celestial Arts Academy", null },
                    { 4, 1, "Shaping visionary leaders for the global business landscape.", "Stellar Business School", null },
                    { 5, 1, "Advancing healthcare through research, education, and compassionate practice.", "Lunar Medical University", null },
                    { 6, 1, "Exploring the mysteries of the cosmos through scientific inquiry.", "Astrological Sciences Institute", null },
                    { 7, 1, "Fostering environmental stewardship and sustainability for a brighter future.", "Nova Environmental Studies Center", null },
                    { 8, 1, "Training the next generation of engineers to build a better universe.", "Cosmic Engineering Academy", null },
                    { 9, 1, "Dedicated to legal excellence and justice in the interstellar community.", "Eclipse Law School", null },
                    { 10, 1, "Unraveling the mysteries of the cosmos through rigorous scientific study.", "Astronomy and Astrophysics College", null },
                    { 11, 1, "Understanding society and its dynamics on a global scale for a harmonious future.", "Interplanetary Social Sciences Institute", null },
                    { 12, 1, "Pushing the boundaries of computing to unlock new frontiers in technology.", "Quantum Computing Research Center", null }
                });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "name", "UniversityId" },
                values: new object[,]
                {
                    { 1, "Faculty of Science", 1 },
                    { 2, "School of Engineering", 1 },
                    { 3, "College of Arts and Humanities", 1 },
                    { 4, "Business and Economics Department", 1 },
                    { 5, "Medical School", 1 },
                    { 6, "Astronomy and Astrophysics Department", 1 },
                    { 7, "Environmental Studies Division", 1 },
                    { 8, "Law and Legal Studies", 1 },
                    { 9, "Social Sciences Institute", 1 },
                    { 10, "School of Computing", 1 },
                    { 11, "Music and Performing Arts Department", 1 },
                    { 12, "Quantum Computing Research Division", 1 },
                    { 13, "Computer Science and Engineering", 2 },
                    { 14, "Mechanical Engineering Department", 2 },
                    { 15, "Electrical and Electronics Division", 2 },
                    { 16, "Biotechnology and Life Sciences", 2 },
                    { 17, "Business Analytics and Economics", 2 },
                    { 18, "Robotics and Automation Institute", 2 },
                    { 19, "Cybersecurity Research Center", 2 },
                    { 20, "Aviation and Aerospace Studies", 2 },
                    { 21, "Virtual Reality and Gaming Department", 2 },
                    { 22, "Applied Physics and Mathematics", 2 },
                    { 23, "Industrial Design and Innovation", 2 },
                    { 24, "Space Exploration Division", 2 },
                    { 25, "Fine Arts and Sculpture", 3 },
                    { 26, "Drama and Performing Arts", 3 },
                    { 27, "Creative Writing and Literature", 3 },
                    { 28, "Music Composition and Performance", 3 },
                    { 29, "Digital Media and Design", 3 },
                    { 30, "Fashion Design and Textiles", 3 },
                    { 31, "Photography and Visual Arts", 3 },
                    { 32, "Culinary Arts and Gastronomy", 3 },
                    { 33, "Film Production and Cinematography", 3 },
                    { 34, "Animation and Multimedia Studies", 3 },
                    { 35, "Art History and Criticism", 3 },
                    { 36, "Cultural Studies and Anthropology", 3 },
                    { 37, "Finance and Investment", 4 },
                    { 38, "Marketing and Sales", 4 },
                    { 39, "Management and Leadership", 4 },
                    { 40, "Entrepreneurship and Innovation", 4 },
                    { 41, "Business Analytics and Strategy", 4 },
                    { 42, "Supply Chain and Logistics", 4 },
                    { 43, "Human Resources and Organizational Behavior", 4 },
                    { 44, "International Business Studies", 4 },
                    { 45, "Economics and Global Markets", 4 },
                    { 46, "Corporate Governance and Ethics", 4 },
                    { 47, "Real Estate and Property Management", 4 },
                    { 48, "Hospitality and Tourism Management", 4 },
                    { 49, "Medicine and Surgery", 5 },
                    { 50, "Nursing and Healthcare Management", 5 },
                    { 51, "Pharmacy and Pharmaceutical Sciences", 5 },
                    { 52, "Dentistry and Oral Health", 5 },
                    { 53, "Medical Research and Biotechnology", 5 },
                    { 54, "Public Health and Epidemiology", 5 },
                    { 55, "Nutrition and Dietetics", 5 },
                    { 56, "Psychology and Mental Health Studies", 5 },
                    { 57, "Rehabilitation Sciences", 5 },
                    { 58, "Veterinary Medicine", 5 },
                    { 59, "Medical Ethics and Legal Studies", 5 },
                    { 60, "Alternative and Complementary Medicine", 5 },
                    { 61, "Astrology and Horoscopes", 6 },
                    { 62, "Celestial Mathematics", 6 },
                    { 63, "Planetary Physics", 6 },
                    { 64, "Mystical Astronomy", 6 },
                    { 65, "Astrological Data Science", 6 },
                    { 66, "Astrobiology and Extraterrestrial Life", 6 },
                    { 67, "Cosmic Phenomena Studies", 6 },
                    { 68, "Astrological Arts and Culture", 6 },
                    { 69, "Zodiacal Psychology", 6 },
                    { 70, "Astrological Predictive Modeling", 6 },
                    { 71, "Stellar Cartography", 6 },
                    { 72, "Quantum Astrology Research", 6 },
                    { 73, "Ecology and Biodiversity", 7 },
                    { 74, "Environmental Policy and Governance", 7 },
                    { 75, "Renewable Energy and Sustainability", 7 },
                    { 76, "Climate Change and Adaptation", 7 },
                    { 77, "Marine Biology and Oceanography", 7 },
                    { 78, "Environmental Chemistry and Toxicology", 7 },
                    { 79, "Green Architecture and Urban Planning", 7 },
                    { 80, "Wildlife Conservation and Management", 7 },
                    { 81, "Environmental Engineering", 7 },
                    { 82, "Sustainable Agriculture and Food Systems", 7 },
                    { 83, "Ecotourism and Nature-Based Recreation", 7 },
                    { 84, "Environmental Ethics and Philosophy", 7 },
                    { 85, "International Law and Diplomacy", 8 },
                    { 86, "Criminal Law and Justice", 8 },
                    { 87, "Corporate and Business Law", 8 },
                    { 88, "Human Rights and Social Justice", 8 },
                    { 89, "Environmental Law and Sustainability", 8 },
                    { 90, "Intellectual Property and Technology Law", 8 },
                    { 91, "Health Law and Bioethics", 8 },
                    { 92, "Legal Studies and Ethics", 8 },
                    { 93, "Family and Juvenile Law", 8 },
                    { 94, "International Humanitarian Law", 8 },
                    { 95, "Alternative Dispute Resolution", 8 },
                    { 96, "Space Law and Policy", 8 },
                    { 97, "Quantum Algorithms and Complexity", 12 },
                    { 98, "Quantum Machine Learning", 12 },
                    { 99, "Quantum Cryptography", 12 },
                    { 100, "Quantum Information and Entanglement", 12 },
                    { 101, "Quantum Hardware Development", 12 },
                    { 102, "Quantum Software Engineering", 12 },
                    { 103, "Quantum Networking", 12 },
                    { 104, "Quantum Artificial Intelligence", 12 },
                    { 105, "Quantum Simulation", 12 },
                    { 106, "Quantum Error Correction", 12 },
                    { 107, "Quantum Ethics and Philosophy", 12 },
                    { 108, "Quantum Computing and Astrophysics", 12 },
                    { 109, "Observational Astronomy", 9 },
                    { 110, "Theoretical Astrophysics", 9 },
                    { 111, "Planetary Science and Geophysics", 9 },
                    { 112, "Astrochemistry and Astrobiology", 9 },
                    { 113, "Galactic Dynamics and Cosmology", 9 },
                    { 114, "Astroinformatics and Data Science", 9 },
                    { 115, "Exoplanetary Studies", 9 },
                    { 116, "Space Mission Planning and Engineering", 9 },
                    { 117, "Astrophysical Instrumentation", 9 },
                    { 118, "Astrosociology and Cultural Astronomy", 9 },
                    { 119, "Radio Astronomy and Signal Processing", 9 },
                    { 120, "Dark Matter and Dark Energy Research", 9 },
                    { 121, "Interstellar Relations", 10 },
                    { 122, "Intergalactic Sociology", 10 },
                    { 123, "Astropolitical Science", 10 },
                    { 124, "Planetary Economics", 10 },
                    { 125, "Space Anthropology", 10 },
                    { 126, "Astrosociology and Extraterrestrial Cultures", 10 },
                    { 127, "Planetary Governance and Policy Studies", 10 },
                    { 128, "Space Psychology", 10 },
                    { 129, "Astroethics and Intergalactic Morality", 10 },
                    { 130, "Exosociology and Alien Civilizations", 10 },
                    { 131, "Astrohistory and Futurology", 10 },
                    { 132, "Interplanetary Communication Studies", 10 },
                    { 133, "Quantum Algorithms and Complexity", 11 },
                    { 134, "Quantum Machine Learning", 11 },
                    { 135, "Quantum Cryptography", 11 },
                    { 136, "Quantum Information and Entanglement", 11 },
                    { 137, "Quantum Hardware Development", 11 },
                    { 138, "Quantum Software Engineering", 11 },
                    { 139, "Quantum Networking", 11 },
                    { 140, "Quantum Artificial Intelligence", 11 },
                    { 141, "Quantum Simulation", 11 },
                    { 142, "Quantum Error Correction", 11 },
                    { 143, "Quantum Ethics and Philosophy", 11 },
                    { 144, "Quantum Computing and Astrophysics", 11 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 12);
        }
    }
}
