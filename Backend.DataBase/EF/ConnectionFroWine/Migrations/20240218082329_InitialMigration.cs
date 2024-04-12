using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataBase.EF.ConnectionFroWine.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"--WineReferenceInformations
                                        INSERT INTO ""WineReferenceInformations"" VALUES (1, 'Для эффективного управления этим процессом и прогнозирования его результатов широко используются различные математические модели. Одной из основных моделей прогнозирования брожения вина является модель ферментации, которая основывается на биохимических реакциях, происходящих в процессе брожения. Эта модель учитывает изменения концентрации сахара, алкоголя, кислот и других компонентов в процессе времени, а также влияние температуры, pH и других факторов на скорость и направление реакций. Другой распространенной моделью является модель Гомпертца, которая описывает кривую роста микроорганизмов во времени. Эта модель хорошо подходит для анализа динамики процесса брожения, учитывая, что брожение вина осуществляется за счет деятельности дрожжей, которые также подчиняются законам роста и размножения. Кроме того, существуют статистические модели, которые используются для анализа и прогнозирования временных рядов, таких как изменение уровня алкоголя, pH и других параметров во времени. Эти модели могут помочь предсказать конечный результат процесса брожения на основе данных о его динамике в прошлом. Современные методы анализа данных, такие как машинное обучение и искусственные нейронные сети, также находят применение в прогнозировании процесса брожения вина. Эти методы могут обрабатывать большие объемы данных и выявлять сложные взаимосвязи между различными параметрами, что помогает улучшить точность прогнозирования и оптимизировать условия производства. В целом, разнообразие математических моделей прогнозирования процесса брожения вина позволяет виноделам эффективно управлять производством, достигать желаемых характеристик и обеспечивать стабильное качество продукции. Применение этих моделей в сочетании с практическим опытом и экспертными знаниями играет ключевую роль в развитии виноделия и создании высококачественных вин.', 1);
                                        INSERT INTO ""WineReferenceInformations"" VALUES (2, 'Шаптализация вина представляет собой процесс, используемый в виноделии для регулирования уровня сахара в виноградном соке перед началом процесса брожения. Этот метод широко применяется в регионах с прохладным климатом или в годах, когда виноград созревает с недостаточным содержанием сахара для получения качественного вина. Суть процесса заключается в добавлении сахара в сок, чтобы повысить его концентрацию и, следовательно, потенциальный уровень алкоголя в конечном продукте. Обычно для этого используется сахара виноградного или нерафинированного сахара, хотя также могут применяться другие источники сахара. Шаптализация позволяет виноделам контролировать содержание алкоголя и сладости вина, что в свою очередь влияет на его вкусовые характеристики, аромат и стиль. Данный метод также позволяет более точно управлять процессом брожения и получать более предсказуемый конечный результат, особенно в условиях переменного климата или нестабильного урожая. Однако, необходимо учитывать, что шаптализация может повлиять на характер вина, особенно если сахар добавляется в больших количествах. Это может привести к изменению баланса между кислотностью и сладостью, а также влиять на комплексность вкуса и аромата. Кроме того, в некоторых регионах законодательство устанавливает ограничения на использование шаптализации, определяя максимально допустимые уровни сахара, которые можно добавить к вину.', 2);
                                        INSERT INTO ""WineReferenceInformations"" VALUES (3, 'Купажирование вина представляет собой искусство создания уникального и сбалансированного продукта путем смешивания различных сортов винограда или вин разного происхождения. Этот процесс является одним из ключевых этапов виноделия, где виноделы сочетают вина с целью достижения определенного вкуса, аромата и стиля. Главная цель купажирования заключается в создании вина, которое выделяется высоким качеством и характером, недоступным при использовании отдельных компонентов. Для этого виноделы учитывают множество факторов, включая характеристики винограда, климатические условия урожая, свойства почвы, а также технические параметры производства. В процессе купажирования важно обеспечить сбалансированность вина, где каждый компонент дополняет другие, создавая гармоничное сочетание вкусовых и ароматических нот. Также важно сохранить выразительные характеристики винограда и региона, что придает вину уникальность и подлинность. Купажирование позволяет виноделам контролировать и корректировать характеристики вина, такие как кислотность, сладость, таннинность и структура, чтобы создать идеальный баланс в конечном продукте. Этот процесс также способствует созданию вин с постоянным стилем и качеством, обеспечивая стабильность и непрерывность вкусовых характеристик. Кроме того, купажирование открывает возможности для экспериментов и инноваций, позволяя виноделам создавать новые и уникальные вкусовые профили, а также адаптироваться к изменяющимся рыночным требованиям и вкусам потребителей.', 3);
                                        INSERT INTO ""WineReferenceInformations"" VALUES (4, 'Крепление вина - это процесс, направленный на увеличение содержания алкоголя в вине путем добавления спиртосодержащего напитка, обычно винного спирта. Этот процесс применяется в виноделии с целью корректировки уровня алкоголя в конечном продукте, а также для придания вину определенных характеристик и стиля. Главная цель крепления вина заключается в достижении определенного уровня алкоголя, который может быть важным для определенных вин или стилей, либо чтобы сделать вино более устойчивым к хранению. Для этого в виноделии используются различные методы, включая добавление чистого спирта или алкогольных напитков, таких как коньяк или бренди. Крепление вина может происходить в различных стадиях производства. Некоторые виноделы предпочитают добавлять спирт в сок винограда до начала процесса брожения, что приводит к созданию так называемого ""фортифицированного"" вина. Другие могут крепить вино после завершения брожения, чтобы сохранить его естественные ароматы и вкусовые характеристики. Одним из самых известных примеров крепленых вин является портвейн, который производится в Португалии и крепится добавлением коньяка. Крепленные вина также включают шерри, мадеру и марсалу, каждое из которых имеет свои уникальные процессы производства и стили. Важно отметить, что крепление вина может оказывать значительное влияние на его вкус, аромат и стиль. Добавление спирта может изменить баланс между сладостью и кислотностью, а также влиять на структуру и тело вина. Поэтому виноделы должны проявлять осторожность и внимательность при применении этого процесса, чтобы сохранить качество и целостность конечного продукта.', 4);

                                        -- WineTypicalEvents
                                        INSERT INTO ""WineTypicalEvents"" VALUES (1, 'Шаптализация', 1);
                                        INSERT INTO ""WineTypicalEvents"" VALUES (2, 'Купажирование', 2);
                                        INSERT INTO ""WineTypicalEvents"" VALUES (3, 'Крепление', 3);

                                        -- WineUsers
                                        INSERT INTO ""WineUsers"" VALUES (1, 'qwe', 'qwe', 1);
                                        INSERT INTO ""WineUsers"" VALUES (2, 'qwer', 'qwer', 2);

                                        -- GrapeVarieties
                                        INSERT INTO ""GrapeVarieties"" VALUES(1, 'Августин (V-25/20)', 17 , 8.7);
                                        INSERT INTO ""GrapeVarieties"" VALUES(2, 'Агадаи', 14.5 , 6.9);
                                        INSERT INTO ""GrapeVarieties"" VALUES(3, 'Агат донской', 14.3 , 6.6);
                                        INSERT INTO ""GrapeVarieties"" VALUES(4, 'Аг изюм', 19.1 , 7);
                                        INSERT INTO ""GrapeVarieties"" VALUES(5, 'Ананасный', 21.2 , 6.4);
                                        INSERT INTO ""GrapeVarieties"" VALUES(6, 'Белорозовый', 18 , 5);
                                        INSERT INTO ""GrapeVarieties"" VALUES(7, 'Богатырский', 18.2 , 6.9);
                                        INSERT INTO ""GrapeVarieties"" VALUES(8, 'Богларка(КМ-159)', 13.9 , 6.9);
                                        INSERT INTO ""GrapeVarieties"" VALUES(9, 'Восторг', 16.8 , 6);
                                        INSERT INTO ""GrapeVarieties"" VALUES(10, 'Декабрьский', 19 , 8.4);
                                        INSERT INTO ""GrapeVarieties"" VALUES(11, 'Десертный', 19.6 , 7.3);
                                        INSERT INTO ""GrapeVarieties"" VALUES( 12,'Дольчатый', 13.4 , 9.7);
                                        INSERT INTO ""GrapeVarieties"" VALUES(13, 'Донская роза', 18.1 , 7.2);
                                        INSERT INTO ""GrapeVarieties"" VALUES(14, 'Донской алый', 17.9 , 8.7);
                                        INSERT INTO ""GrapeVarieties"" VALUES(15, 'Жемчуг Саба', 18.4 , 6.6);
                                        INSERT INTO ""GrapeVarieties"" VALUES(16, 'Зоревой', 17.5 , 5.7);
                                        INSERT INTO ""GrapeVarieties"" VALUES(17, 'Карабурну', 18.2 , 7.6);
                                        INSERT INTO ""GrapeVarieties"" VALUES(18, 'Карамол', 16.3 , 6.8);
                                        INSERT INTO ""GrapeVarieties"" VALUES(19, 'Кишмиш лучистый', 15.7 , 7);
                                        INSERT INTO ""GrapeVarieties"" VALUES(20, 'Кишмиш черный', 22.2 , 6.7);
                                        INSERT INTO ""GrapeVarieties"" VALUES(21, 'Кодрянка', 16.2 , 6.8);
                                        INSERT INTO ""GrapeVarieties"" VALUES(22, 'Королева виноградников', 16 , 6);
                                        INSERT INTO ""GrapeVarieties"" VALUES(23, 'Крымская жемчужина', 18.2 , 8.1);
                                        INSERT INTO ""GrapeVarieties"" VALUES(24, 'Кутузовский', 15.7 , 10.1);
                                        INSERT INTO ""GrapeVarieties"" VALUES(25, 'Ляна', 17.8 , 7.6);
                                        INSERT INTO ""GrapeVarieties"" VALUES(26, 'Мадлен Анжевин', 16.8 , 6.3);
                                        INSERT INTO ""GrapeVarieties"" VALUES(27, 'Май-гуй-Сан', 20.2 , 7.5);
                                        INSERT INTO ""GrapeVarieties"" VALUES(28, 'Мискет дунавски', 16.9 , 7.3);
                                        INSERT INTO ""GrapeVarieties"" VALUES(29, 'Молдова', 15.6 , 11.7);
                                        INSERT INTO ""GrapeVarieties"" VALUES(30, 'Муромец', 15.9 , 7.2);
                                        INSERT INTO ""GrapeVarieties"" VALUES(31, 'Мускат гамбургский', 21.6 , 7.8);
                                        INSERT INTO ""GrapeVarieties"" VALUES(32, 'Мускат дербентский', 17.6 , 8);
                                        INSERT INTO ""GrapeVarieties"" VALUES(33, 'Мускат узбекистанский', 19 , 7.7);
                                        INSERT INTO ""GrapeVarieties"" VALUES(34, 'Мускат янтарный', 17.7 , 7);
                                        INSERT INTO ""GrapeVarieties"" VALUES(35, 'Осенний черный', 16 , 10.8);
                                        INSERT INTO ""GrapeVarieties"" VALUES(36, 'Особый', 17 , 6.6);
                                        INSERT INTO ""GrapeVarieties"" VALUES(37, 'Памяти Котовского', 16.6 , 10.3);
                                        INSERT INTO ""GrapeVarieties"" VALUES(38, 'Перла Бухареста', 16.2 , 9.2);
                                        INSERT INTO ""GrapeVarieties"" VALUES(39, 'Пестроцветный', 17 , 6.8);
                                        INSERT INTO ""GrapeVarieties"" VALUES(40, 'Пионер Одессы', 14.3 , 6.6);
                                        INSERT INTO ""GrapeVarieties"" VALUES(41, 'Премьер', 17.5 , 5.7);
                                        INSERT INTO ""GrapeVarieties"" VALUES(42, 'Ромулус', 21.6 , 6.9);
                                        INSERT INTO ""GrapeVarieties"" VALUES(43, 'Русбол', 16.6 , 7.4);
                                        INSERT INTO ""GrapeVarieties"" VALUES(44, 'Русмол', 15.6 , 8.2);
                                        INSERT INTO ""GrapeVarieties"" VALUES(45, 'Сверхранний волгодонскии', 16.4 , 9.2);
                                        INSERT INTO ""GrapeVarieties"" VALUES(46, 'Сенека', 17.6 , 6.7);
                                        INSERT INTO ""GrapeVarieties"" VALUES(47, 'Сенсо', 19.6 , 8);
                                        INSERT INTO ""GrapeVarieties"" VALUES(48, 'Скоренский красный', 15.2 , 9.4);
                                        INSERT INTO ""GrapeVarieties"" VALUES(49, 'Стелла', 17.7 , 9);
                                        INSERT INTO ""GrapeVarieties"" VALUES(50, 'Тавриз', 19.9 , 6);
                                        INSERT INTO ""GrapeVarieties"" VALUES(51, 'Тавроси', 17.8 , 9.9);
                                        INSERT INTO ""GrapeVarieties"" VALUES(52, 'Таировский огонек', 17 , 8);
                                        INSERT INTO ""GrapeVarieties"" VALUES(53, 'Танаис', 16.9 , 7);
                                        INSERT INTO ""GrapeVarieties"" VALUES(54, 'Тасон', 16.8 , 5.6);
                                        INSERT INTO ""GrapeVarieties"" VALUES(55, 'Томайский', 17.5 , 6.6);
                                        INSERT INTO ""GrapeVarieties"" VALUES(56, 'Урожайный', 14.1 , 9.4);
                                        INSERT INTO ""GrapeVarieties"" VALUES(57, 'Фрумоаса албэ', 18.1 , 6.5);
                                        INSERT INTO ""GrapeVarieties"" VALUES(58, 'Шасла белая', 16.9 , 6.3);
                                        INSERT INTO ""GrapeVarieties"" VALUES(59, 'Шасла мускатная', 17.1 , 6.7);
                                        INSERT INTO ""GrapeVarieties"" VALUES(60, 'Шасла розовая', 18.1 , 7);
                                        INSERT INTO ""GrapeVarieties"" VALUES(61, 'Южный (V-72-58)', 16.5 , 10.3);
                                        INSERT INTO ""GrapeVarieties"" VALUES(62, 'Яловенский столовый', 17 , 9.1);

                                        --AreometrDefaultValues
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (1, 1034, 6.3);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (2, 1035, 6.6);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (3, 1036, 6.9);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (4, 1037, 7.2);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (5, 1038, 7.4);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (6, 1039, 7.6);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (7, 1040, 8);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (8, 1041, 8.2);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (9, 1042, 8.4);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (10, 1043, 8.7);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (11, 1044, 9);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (12, 1045, 9.2);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (13, 1046, 9.5);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (14, 1047, 9.8);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (15, 1048, 10);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (16, 1049, 10.3);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (17, 1050, 10.6);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (18, 1051, 10.8);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (19, 1052, 11.1);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (20, 1053, 11.4);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (21, 1054, 11.6);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (22, 1055, 11.9);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (23, 1056, 12.2);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (24, 1057, 12.4);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (25, 1058, 12.7);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (26, 1059, 13);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (27, 1060, 13.2);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (28, 1061, 13.5);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (29, 1061, 13.8);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (30, 1062, 14);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (31, 1063, 14.3);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (32, 1070, 15.9);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (33, 1071, 16.2);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (34, 1072, 16.4);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (35, 1073, 16.7);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (36, 1074, 17);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (37, 1075, 17.2);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (38, 1076, 17.5);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (39, 1077, 17.8);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (40, 1078, 18);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (41, 1079, 18.3);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (42, 1080, 18.6);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (43, 1081, 18.8);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (44, 1082, 19.1);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (45, 1083, 19.4);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (46, 1084, 19.6);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (47, 1085, 19.9);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (48, 1086, 20.2);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (49, 1087, 20.4);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (50, 1088, 20.7);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (51, 1089, 21);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (52, 1090, 21.2);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (53, 1091, 21.5);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (54, 1092, 21.8);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (55, 1093, 22);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (56, 1094, 22.3);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (57, 1095, 22.6);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (58, 1096, 22.8);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (59, 1097, 23.1);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (60, 1098, 23.4);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (61, 1099, 23.6);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (62, 1100, 23.9);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (63, 1105, 25.2);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (64, 1106, 25.5);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (65, 1107, 25.8);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (66, 1108, 26);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (67, 1109, 26.3);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (68, 1110, 26.6);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (69, 1111, 26.9);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (70, 1112, 27.1);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (71, 1113, 27.4);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (72, 1114, 27.6);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (73, 1115, 27.9);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (74, 1116, 28.2);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (75, 1117, 28.4);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (76, 1118, 28.8);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (77, 1119, 29);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (78, 1120, 29.3);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (79, 1121, 29.6);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (80, 1122, 29.8);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (81, 1123, 30.1);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (82, 1124, 30.3);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (83, 1125, 30.6);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (84, 1126, 30.9);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (85, 1127, 31.1);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (86, 1128, 31.4);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (87, 1129, 31.6);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (88, 1130, 31.9);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (89, 1131, 32.2);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (90, 1132, 32.5);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (91, 1133, 32.7);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (92, 1134, 33);
                                        INSERT INTO ""AreometrDefaultValues"" VALUES (93, 1135, 33.3);");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM ""AreometrDefaultValues"";
                                    DELETE FROM ""GrapeVarieties"";
                                    DELETE FROM ""WineUsers"";
                                    DELETE FROM ""WineReferenceInformations"";
                                    DELETE FROM ""WineTypicalEvents"";");
        }
    }
}
