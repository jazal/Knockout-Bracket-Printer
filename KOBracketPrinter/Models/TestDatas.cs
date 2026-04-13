namespace KOBracketPrinter.Models;

public class TestDatas
{
    public static PrintRequestDto Get4()
    {
        return new PrintRequestDto()
        {
            EventCategoryTitle = "Test 4",
            PlayerCount = "4",
            Matches = new List<PrintRequestMatchDto>()
            {
                new PrintRequestMatchDto(1, 1, "A", "B", null, null, 1, 16),
                new PrintRequestMatchDto(2, 1, "C", "D", 0, 3, 9, 8),
                
                new PrintRequestMatchDto(3, 2, "A", "D", 1, 3, null, null),
            }
        };
    }

    public static PrintRequestDto Get8()
    {
        return new PrintRequestDto()
        {
            EventCategoryTitle = "Test 8",
            PlayerCount = "8",
            Matches = new List<PrintRequestMatchDto>()
            {
                new PrintRequestMatchDto(1, 1, "A", "", null, null, 1, 16),
                new PrintRequestMatchDto(2, 1, "C", "D", 0, 3, 9, 8),
                new PrintRequestMatchDto(3, 1, "E", "F", 3, 2, 5, 12),
                new PrintRequestMatchDto(4, 1, "G", "", null, null, 13, 4),
                
                new PrintRequestMatchDto(5, 2, "A", "D", 1, 3, null, null),
                new PrintRequestMatchDto(6, 2, "E", "G", 3, 1, null, null),
                
                new PrintRequestMatchDto(7, 3, "D", "E", 3, 1, null, null),
                
            }
        };
    }

    public static PrintRequestDto Get16()
    {
        return new PrintRequestDto()
        {
            EventCategoryTitle = "Test 16",
            PlayerCount = "16",
            Matches = new List<PrintRequestMatchDto>()
            {
                new PrintRequestMatchDto(1, 1, "", "", null, null, 1, 16),
                new PrintRequestMatchDto(2, 1, "", "", 0, 3, 9, 8),
                new PrintRequestMatchDto(3, 1, "", "", 3, 2, 5, 12),
                new PrintRequestMatchDto(4, 1, "", "", null, null, 13, 4),
                new PrintRequestMatchDto(5, 1, "", "", null, null, 3, 14),
                new PrintRequestMatchDto(6, 1, "", "", 0, 3, 11, 6),
                new PrintRequestMatchDto(7, 1, "", "", 3, 1, 7, 10),
                new PrintRequestMatchDto(8, 1, "", "", null, null, 15, 2),
                new PrintRequestMatchDto(9, 2, "", "", 1, 3, null, null),
                new PrintRequestMatchDto(10, 2, "", "", 3, 1, null, null),
                new PrintRequestMatchDto(11, 2, "", "", 0, 3, null, null),
                new PrintRequestMatchDto(12, 2, "", "", 3, 2, null, null),
                new PrintRequestMatchDto(13, 3, "", "", 3, 1, null, null),
                new PrintRequestMatchDto(14, 3, "", "", 3, 0, null, null),
                new PrintRequestMatchDto(15, 4, "", "", 3, 2, null, null),
            }
        };
    }

    public static PrintRequestDto Get32()
    {
        return new PrintRequestDto()
        {
            EventCategoryTitle = "Test 32",
            PlayerCount = "32",
            Matches = new List<PrintRequestMatchDto>()
            {
                new PrintRequestMatchDto(1, 1, "155eb719-7e3b", "00000000-0000", null, null, 1, 32),
                new PrintRequestMatchDto(2, 1, "9f71dada-8bd9", "91e13f42-2dfe", 2, 4, 17, 16),
                new PrintRequestMatchDto(3, 1, "4467e292-f6d9", "00000000-0000", null, null, 9, 24),
                new PrintRequestMatchDto(4, 1, "00000000-0000", "ed95e4f1-6a31", null, null, 25, 8),
                new PrintRequestMatchDto(5, 1, "46f864d6-a73c", "00000000-0000", null, null, 5, 28),
                new PrintRequestMatchDto(6, 1, "794e97dc-6bec", "ec2b7845-3a8c", 0, 4, 21, 12),
                new PrintRequestMatchDto(7, 1, "3bd0c199-4eca", "61e626fe-8f36", 4, 1, 13, 20),
                new PrintRequestMatchDto(8, 1, "00000000-0000", "51adc64c-4e35", null, null, 29, 4),
                new PrintRequestMatchDto(9, 1, "113b1f2f-29aa", "00000000-0000", null, null, 3, 30),
                new PrintRequestMatchDto(10, 1, "13b52da6-cb5f", "3338d0e3-4ef5", 3, 4, 19, 14),
                new PrintRequestMatchDto(11, 1, "f880a3b0-9145", "cd0b820d-15e4", 4, 1, 11, 22),
                new PrintRequestMatchDto(12, 1, "00000000-0000", "02ae752b-2e8a", null, null, 27, 6),
                new PrintRequestMatchDto(13, 1, "0dae3cc4-fe24", "00000000-0000", null, null, 7, 26),
                new PrintRequestMatchDto(14, 1, "00000000-0000", "7c4d01aa-18ce", null, null, 23, 10),
                new PrintRequestMatchDto(15, 1, "4e1b1f04-3984", "c31513e2-5444", 4, 0, 15, 18),
                new PrintRequestMatchDto(16, 1, "00000000-0000", "7d1aae0b-5d7d", null, null, 31, 2),
                new PrintRequestMatchDto(17, 2, "155eb719-7e3b", "91e13f42-2dfe", 4, 0, null, null),
                new PrintRequestMatchDto(18, 2, "4467e292-f6d9", "ed95e4f1-6a31", 4, 3, null, null),
                new PrintRequestMatchDto(19, 2, "46f864d6-a73c", "ec2b7845-3a8c", 4, 0, null, null),
                new PrintRequestMatchDto(20, 2, "3bd0c199-4eca", "51adc64c-4e35", 1, 4, null, null),
                new PrintRequestMatchDto(21, 2, "113b1f2f-29aa", "3338d0e3-4ef5", 2, 4, null, null),
                new PrintRequestMatchDto(22, 2, "f880a3b0-9145", "02ae752b-2e8a", 4, 0, null, null),
                new PrintRequestMatchDto(23, 2, "0dae3cc4-fe24", "7c4d01aa-18ce", 4, 1, null, null),
                new PrintRequestMatchDto(24, 2, "4e1b1f04-3984", "7d1aae0b-5d7d", 4, 3, null, null),
                new PrintRequestMatchDto(25, 3, "155eb719-7e3b", "4467e292-f6d9", 0, 4, null, null),
                new PrintRequestMatchDto(26, 3, "46f864d6-a73c", "51adc64c-4e35", 3, 4, null, null),
                new PrintRequestMatchDto(27, 3, "3338d0e3-4ef5", "f880a3b0-9145", 2, 4, null, null),
                new PrintRequestMatchDto(28, 3, "0dae3cc4-fe24", "4e1b1f04-3984", 4, 0, null, null),
                new PrintRequestMatchDto(29, 4, "4467e292-f6d9", "51adc64c-4e35", 4, 3, null, null),
                new PrintRequestMatchDto(30, 4, "f880a3b0-9145", "0dae3cc4-fe24", 0, 4, null, null),
                new PrintRequestMatchDto(31, 5, "4467e292-f6d9", "0dae3cc4-fe24", 4, 1, null, null),
            }
        };
    }

    public static PrintRequestDto Get64()
    {
        return new PrintRequestDto()
        {
            EventCategoryTitle = "Test 64",
            PlayerCount = "64",
            Matches = new List<PrintRequestMatchDto>()
            {
                new PrintRequestMatchDto(1,1,"eb1d95ad-d479", "2c83b6c4-5f08",4, 11, 1,64),
                new PrintRequestMatchDto(2,1,"da3ce3f9-4903", "13897ce3-6600",9, 11, 33,32),
                new PrintRequestMatchDto(3,1,"c847a119-c98d", "fe9d328b-5093",5, 11, 17,48),
                new PrintRequestMatchDto(4,1,"a4de7af8-e34c", "633e1948-8b52",4, 11, 49,16),
                new PrintRequestMatchDto(5,1,"59987b15-2aca", "782b9b3b-efb8",11, 2, 9,56),
                new PrintRequestMatchDto(6,1,"03f910e2-7bfd", "a0c169ba-d327",11, 8, 41,24),
                new PrintRequestMatchDto(7,1,"3f4706e1-dce5", "a910ec04-4244",7, 11, 25,40),
                new PrintRequestMatchDto(8,1,"d0363371-3017", "3adfe3e2-6fe0",6, 11, 57,8),
                new PrintRequestMatchDto(9,1,"dd581188-066e", "7f5aad8a-65fe",11, 7, 5,60),
                new PrintRequestMatchDto(10,1,"0c849a0e-c25f", "860cd932-9fa3",6, 11, 37,28),
                new PrintRequestMatchDto(11,1,"aa147cbc-5416", "d2ca6cd4-2127",2, 11, 21,44),
                new PrintRequestMatchDto(12,1,"46f864d6-a73c", "e0556bde-229b",4, 11, 53,12),
                new PrintRequestMatchDto(13,1,"85cd5bb6-e84b", "e5ce266c-582d",11, 9, 13,52),
                new PrintRequestMatchDto(14,1,"0b7101be-896e", "aa296f75-d677",2, 11, 45,20),
                new PrintRequestMatchDto(15,1,"6dc335dc-6930", "28075262-79d2",11, 10, 29,36),
                new PrintRequestMatchDto(16,1,"c3ec0368-b022", "679d0b45-eed4",11, 7, 61,4),
                new PrintRequestMatchDto(17,1,"eb60bff0-107c", "3c84c60f-a137",11, 7, 3,62),
                new PrintRequestMatchDto(18,1,"3ef3fff5-14c1", "8596e375-7cfb",8, 11, 35,30),
                new PrintRequestMatchDto(19,1,"09f34b49-d772", "674afa6c-f683",11, 6, 19,46),
                new PrintRequestMatchDto(20,1,"50bb806b-5f0c", "0a3671b8-2109",11, 10, 51,14),
                new PrintRequestMatchDto(21,1,"8b205025-b5cc", "46e194c6-5cfb",11, 10, 11,54),
                new PrintRequestMatchDto(22,1,"ae1d2282-8cf1", "5951691f-7d8d",7, 11, 43,22),
                new PrintRequestMatchDto(23,1,"020a145f-f90a", "e8637815-7b20",11, 8, 27,38),
                new PrintRequestMatchDto(24,1,"3d1fabd5-e583", "2e021186-ef3e",10, 11, 59,6),
                new PrintRequestMatchDto(25,1,"ea66dd12-fbd3", "9c1c32c4-7829",11, 10, 7,58),
                new PrintRequestMatchDto(26,1,"79e1d0c0-14de", "ef495584-4c63",10, 11, 39,26),
                new PrintRequestMatchDto(27,1,"8642dead-8919", "e1e9e53b-95ac",5, 11, 23,42),
                new PrintRequestMatchDto(28,1,"ae29f829-7530", "08a0576d-da19",1, 11, 55,10),
                new PrintRequestMatchDto(29,1,"0a88370d-cdc1", "b4c2d8cf-d858",11, 9, 15,50),
                new PrintRequestMatchDto(30,1,"fedcbd3f-361c", "fce40cfb-03df",4, 11, 47,18),
                new PrintRequestMatchDto(31,1,"d77a9bd2-5b5b", "89144a9d-85cf",9, 11, 31,34),
                new PrintRequestMatchDto(32,1,"4f0f812c-b38a", "d10c3bd4-4820",11, 8, 63,2),
                new PrintRequestMatchDto(33,2,"2c83b6c4-5f08", "13897ce3-6600",4, 11, null,null),
                new PrintRequestMatchDto(34,2,"fe9d328b-5093", "633e1948-8b52",5, 11, null,null),
                new PrintRequestMatchDto(35,2,"59987b15-2aca", "03f910e2-7bfd",11, 8, null,null),
                new PrintRequestMatchDto(36,2,"a910ec04-4244", "3adfe3e2-6fe0",11, 10, null,null),
                new PrintRequestMatchDto(37,2,"dd581188-066e", "860cd932-9fa3",11, 8, null,null),
                new PrintRequestMatchDto(38,2,"d2ca6cd4-2127", "e0556bde-229b",7, 11, null,null),
                new PrintRequestMatchDto(39,2,"85cd5bb6-e84b", "aa296f75-d677",11, 6, null,null),
                new PrintRequestMatchDto(40,2,"6dc335dc-6930", "c3ec0368-b022",11, 8, null,null),
                new PrintRequestMatchDto(41,2,"eb60bff0-107c", "8596e375-7cfb",9, 11, null,null),
                new PrintRequestMatchDto(42,2,"09f34b49-d772", "50bb806b-5f0c",9, 11, null,null),
                new PrintRequestMatchDto(43,2,"8b205025-b5cc", "5951691f-7d8d",9, 11, null,null),
                new PrintRequestMatchDto(44,2,"020a145f-f90a", "2e021186-ef3e",11, 4, null,null),
                new PrintRequestMatchDto(45,2,"ea66dd12-fbd3", "ef495584-4c63",9, 11, null,null),
                new PrintRequestMatchDto(46,2,"e1e9e53b-95ac", "08a0576d-da19",11, 8, null,null),
                new PrintRequestMatchDto(47,2,"0a88370d-cdc1", "fce40cfb-03df",8, 11, null,null),
                new PrintRequestMatchDto(48,2,"89144a9d-85cf", "4f0f812c-b38a",0, 11, null,null),
                new PrintRequestMatchDto(49,3,"13897ce3-6600", "633e1948-8b52",11, 8, null,null),
                new PrintRequestMatchDto(50,3,"59987b15-2aca", "a910ec04-4244",11, 7, null,null),
                new PrintRequestMatchDto(51,3,"dd581188-066e", "e0556bde-229b",11, 5, null,null),
                new PrintRequestMatchDto(52,3,"85cd5bb6-e84b", "6dc335dc-6930",11, 5, null,null),
                new PrintRequestMatchDto(53,3,"8596e375-7cfb", "50bb806b-5f0c",9, 11, null,null),
                new PrintRequestMatchDto(54,3,"5951691f-7d8d", "020a145f-f90a",11, 3, null,null),
                new PrintRequestMatchDto(55,3,"ef495584-4c63", "e1e9e53b-95ac",3, 11, null,null),
                new PrintRequestMatchDto(56,3,"fce40cfb-03df", "4f0f812c-b38a",11, 10, null,null),
                new PrintRequestMatchDto(57,4,"13897ce3-6600", "59987b15-2aca",11, 7, null,null),
                new PrintRequestMatchDto(58,4,"dd581188-066e", "85cd5bb6-e84b",11, 7, null,null),
                new PrintRequestMatchDto(59,4,"50bb806b-5f0c", "5951691f-7d8d",5, 11, null,null),
                new PrintRequestMatchDto(60,4,"e1e9e53b-95ac", "fce40cfb-03df",11, 5, null,null),
                new PrintRequestMatchDto(61,5,"13897ce3-6600", "dd581188-066e",6, 11, null,null),
                new PrintRequestMatchDto(62,5,"5951691f-7d8d", "e1e9e53b-95ac",11, 9, null,null),
                new PrintRequestMatchDto(63,6,"dd581188-066e", "5951691f-7d8d",13, 9, null,null),
            }
        };
    }

    public static PrintRequestDto Get128()
    {
        return new PrintRequestDto()
        {
            EventCategoryTitle = "Test 128",
            PlayerCount = "128",
            Matches = new List<PrintRequestMatchDto>()
            {
                new PrintRequestMatchDto(1, 1,  "b62938cf-bac8", "39ff008e-e17f", 5,  7,  1,  128),
                new PrintRequestMatchDto(2, 1,  "ec060cbd-78cf", "dc406a44-7967", 3,  7,  65,  64),
                new PrintRequestMatchDto(3, 1,  "87e596d6-0932", "4dd29068-eafd", 5,  7,  33,  96),
                new PrintRequestMatchDto(4, 1,  "1ecf2072-0a4c", "d5975e45-f876", 2,  7,  97,  32),
                new PrintRequestMatchDto(5, 1,  "0e4ad273-071f", "9c1655e1-11b5", 7,  5,  17,  112),
                new PrintRequestMatchDto(6, 1,  "0e8728db-4f0b", "a84eab84-4469", 7,  0,  81,  48),
                new PrintRequestMatchDto(7, 1,  "eb1a76b2-71d9", "860f43bb-7e90", 2,  7,  49,  80),
                new PrintRequestMatchDto(8, 1,  "b52aab45-8bb6", "14875b7b-3118", 3,  7,  113,  16),
                new PrintRequestMatchDto(9, 1,  "223558ee-c55d", "043f6308-5ef0", 7,  4,  9,  120),
                new PrintRequestMatchDto(10, 1,  "5523f24f-564b", "d1196026-8b42", 7,  1,  73,  56),
                new PrintRequestMatchDto(11, 1,  "a4fbce88-ed16", "05a23738-527a", 7,  1,  41,  88),
                new PrintRequestMatchDto(12, 1,  "d0c02964-fa60", "31ec5e23-9874", 7,  1,  105,  24),
                new PrintRequestMatchDto(13, 1,  "826995fa-5317", "da58a7ad-69f4", 4,  7,  25,  104),
                new PrintRequestMatchDto(14, 1,  "bcafe420-ae0c", "a8cb2ff2-c94d", 0,  7,  89,  40),
                new PrintRequestMatchDto(15, 1,  "f0931b4d-caf5", "62975aaa-9933", 7,  4,  57,  72),
                new PrintRequestMatchDto(16, 1,  "957e63b7-cb63", "552ebf32-e56c", 0,  7,  121,  8),
                new PrintRequestMatchDto(17, 1,  "3e4eaa42-ee47", "99407d73-c9c7", 7,  6,  5,  124),
                new PrintRequestMatchDto(18, 1,  "bd29c3e6-03d4", "c43dc586-2a87", 7,  1,  69,  60),
                new PrintRequestMatchDto(19, 1,  "181edb8e-ed7b", "9433c3cc-4415", 7,  5,  37,  92),
                new PrintRequestMatchDto(20, 1,  "5777e02a-1564", "1aeeab5b-2ed0", 1,  7,  101,  28),
                new PrintRequestMatchDto(21, 1,  "11e4a068-75b0", "f0751703-121f", 6,  7,  21,  108),
                new PrintRequestMatchDto(22, 1,  "980af989-da5a", "08fcfa3d-803a", 3,  7,  85,  44),
                new PrintRequestMatchDto(23, 1,  "dc3cd942-db2c", "8e8a7ca2-cb6b", 7,  3,  53,  76),
                new PrintRequestMatchDto(24, 1,  "49e53e89-d2bb", "ae1d2282-8cf1", 1,  7,  117,  12),
                new PrintRequestMatchDto(25, 1,  "d2b996a8-6b33", "a88e37e6-67d3", 7,  0,  13,  116),
                new PrintRequestMatchDto(26, 1,  "06039899-c1b0", "c711f18a-b8f4", 7,  6,  77,  52),
                new PrintRequestMatchDto(27, 1,  "fdc6e51c-f015", "a0e90da4-e7c3", 2,  7,  45,  84),
                new PrintRequestMatchDto(28, 1,  "9ea3c186-eb48", "faa7e4cc-1a51", 6,  7,  109,  20),
                new PrintRequestMatchDto(29, 1,  "92a559dc-ce9f", "77d2e617-374c", 7,  2,  29,  100),
                new PrintRequestMatchDto(30, 1,  "e52ce8e1-ecf6", "54567da0-7c70", 6,  7,  93,  36),
                new PrintRequestMatchDto(31, 1,  "0d4b1d28-755d", "2f8b1d58-9f53", 7,  4,  61,  68),
                new PrintRequestMatchDto(32, 1,  "92783bf7-14a3", "5b662886-6262", 0,  7,  125,  4),
                new PrintRequestMatchDto(33, 1,  "b9f1b817-df9a", "c2290ebf-a56d", 1,  7,  3,  126),
                new PrintRequestMatchDto(34, 1,  "790be137-0852", "ba1779df-7c96", 4,  7,  67,  62),
                new PrintRequestMatchDto(35, 1,  "16cb7cdb-bdbb", "254a640f-0673", 6,  7,  35,  94),
                new PrintRequestMatchDto(36, 1,  "2262f769-b441", "e1dbdea5-4d54", 7,  5,  99,  30),
                new PrintRequestMatchDto(37, 1,  "faea7654-d0ab", "7bc763fb-5314", 7,  2,  19,  110),
                new PrintRequestMatchDto(38, 1,  "dd581188-066e", "66880a50-deb1", 7,  0,  83,  46),
                new PrintRequestMatchDto(39, 1,  "157e8ca8-db42", "0b7101be-896e", 0,  7,  51,  78),
                new PrintRequestMatchDto(40, 1,  "8beeb522-bbfc", "46e9b0a1-25b9", 5,  7,  115,  14),
                new PrintRequestMatchDto(41, 1,  "79e1d0c0-14de", "117e0a51-b06e", 7,  0,  11,  118),
                new PrintRequestMatchDto(42, 1,  "b08e38a3-e180", "bc817ed4-f6ea", 7,  5,  75,  54),
                new PrintRequestMatchDto(43, 1,  "59a615ab-e948", "09474a44-efce", 7,  3,  43,  86),
                new PrintRequestMatchDto(44, 1,  "0122304f-0fe6", "8a84aaa0-3e9e", 2,  7,  107,  22),
                new PrintRequestMatchDto(45, 1,  "cee76aa9-9a7c", "0b44d9d4-80f5", 7,  3,  27,  102),
                new PrintRequestMatchDto(46, 1,  "1b08629a-fd7e", "ce499d3d-da6a", 7,  1,  91,  38),
                new PrintRequestMatchDto(47, 1,  "cfaa52e6-5058", "c342da5c-820d", 3,  7,  59,  70),
                new PrintRequestMatchDto(48, 1,  "f57bce8c-8156", "6572069f-4a57", 1,  7,  123,  6),
                new PrintRequestMatchDto(49, 1,  "cc45c05f-e8ea", "b7b318f5-216f", 7,  3,  7,  122),
                new PrintRequestMatchDto(50, 1,  "4cbe13ae-f2b9", "a91936bc-b5cf", 7,  3,  71,  58),
                new PrintRequestMatchDto(51, 1,  "7695235f-8549", "599548f3-2653", 7,  5,  39,  90),
                new PrintRequestMatchDto(52, 1,  "b122abf1-e448", "76ab34b2-2830", 1,  7,  103,  26),
                new PrintRequestMatchDto(53, 1,  "868965c4-b307", "adfb90f6-4862", 2,  7,  23,  106),
                new PrintRequestMatchDto(54, 1,  "cec17942-f9f5", "06e785fb-b24e", 1,  7,  87,  42),
                new PrintRequestMatchDto(55, 1,  "cd0b820d-15e4", "252414a7-4f03", 7,  3,  55,  74),
                new PrintRequestMatchDto(56, 1,  "3b710e93-ee56", "a5eaa489-0f86", 7,  5,  119,  10),
                new PrintRequestMatchDto(57, 1,  "07d32bae-883f", "baa088ba-6f9f", 7,  5,  15,  114),
                new PrintRequestMatchDto(58, 1,  "28075262-79d2", "dead5bdb-752b", 7,  1,  79,  50),
                new PrintRequestMatchDto(59, 1,  "333632c0-955a", "50bb806b-5f0c", 0,  7,  47,  82),
                new PrintRequestMatchDto(60, 1,  "7b74bd60-bdae", "246662dc-3c9d", 1,  7,  111,  18),
                new PrintRequestMatchDto(61, 1,  "8b7e7a58-8f94", "90a8fdd7-e2d9", 7,  5,  31,  98),
                new PrintRequestMatchDto(62, 1,  "01f36ca0-6afd", "f6f7b9cf-f875", 2,  7,  95,  34),
                new PrintRequestMatchDto(63, 1,  "79d0c885-2b38", "eb09da9d-d93a", 6,  7,  63,  66),
                new PrintRequestMatchDto(64, 1,  "4a7a334c-3420", "b06d8719-e99e", 4,  7,  127,  2),
                new PrintRequestMatchDto(65, 2,  "39ff008e-e17f", "dc406a44-7967", 1,  7,  null,  null),
                new PrintRequestMatchDto(66, 2,  "4dd29068-eafd", "d5975e45-f876", 7,  1,  null,  null),
                new PrintRequestMatchDto(67, 2,  "0e4ad273-071f", "0e8728db-4f0b", 2,  7,  null,  null),
                new PrintRequestMatchDto(68, 2,  "860f43bb-7e90", "14875b7b-3118", 7,  3,  null,  null),
                new PrintRequestMatchDto(69, 2,  "223558ee-c55d", "5523f24f-564b", 7,  6,  null,  null),
                new PrintRequestMatchDto(70, 2,  "a4fbce88-ed16", "d0c02964-fa60", 7,  6,  null,  null),
                new PrintRequestMatchDto(71, 2,  "da58a7ad-69f4", "a8cb2ff2-c94d", 4,  7,  null,  null),
                new PrintRequestMatchDto(72, 2,  "f0931b4d-caf5", "552ebf32-e56c", 5,  7,  null,  null),
                new PrintRequestMatchDto(73, 2,  "3e4eaa42-ee47", "bd29c3e6-03d4", 7,  4,  null,  null),
                new PrintRequestMatchDto(74, 2,  "181edb8e-ed7b", "1aeeab5b-2ed0", 4,  7,  null,  null),
                new PrintRequestMatchDto(75, 2,  "f0751703-121f", "08fcfa3d-803a", 7,  4,  null,  null),
                new PrintRequestMatchDto(76, 2,  "dc3cd942-db2c", "ae1d2282-8cf1", 5,  7,  null,  null),
                new PrintRequestMatchDto(77, 2,  "d2b996a8-6b33", "06039899-c1b0", 0,  7,  null,  null),
                new PrintRequestMatchDto(78, 2,  "a0e90da4-e7c3", "faa7e4cc-1a51", 2,  7,  null,  null),
                new PrintRequestMatchDto(79, 2,  "92a559dc-ce9f", "54567da0-7c70", 7,  1,  null,  null),
                new PrintRequestMatchDto(80, 2,  "0d4b1d28-755d", "5b662886-6262", 1,  7,  null,  null),
                new PrintRequestMatchDto(81, 2,  "c2290ebf-a56d", "ba1779df-7c96", 1,  7,  null,  null),
                new PrintRequestMatchDto(82, 2,  "254a640f-0673", "2262f769-b441", 2,  7,  null,  null),
                new PrintRequestMatchDto(83, 2,  "faea7654-d0ab", "dd581188-066e", 2,  7,  null,  null),
                new PrintRequestMatchDto(84, 2,  "0b7101be-896e", "46e9b0a1-25b9", 7,  3,  null,  null),
                new PrintRequestMatchDto(85, 2,  "79e1d0c0-14de", "b08e38a3-e180", 6,  7,  null,  null),
                new PrintRequestMatchDto(86, 2,  "59a615ab-e948", "8a84aaa0-3e9e", 2,  7,  null,  null),
                new PrintRequestMatchDto(87, 2,  "cee76aa9-9a7c", "1b08629a-fd7e", 7,  3,  null,  null),
                new PrintRequestMatchDto(88, 2,  "c342da5c-820d", "6572069f-4a57", 5,  7,  null,  null),
                new PrintRequestMatchDto(89, 2,  "cc45c05f-e8ea", "4cbe13ae-f2b9", 7,  2,  null,  null),
                new PrintRequestMatchDto(90, 2,  "7695235f-8549", "76ab34b2-2830", 1,  7,  null,  null),
                new PrintRequestMatchDto(91, 2,  "adfb90f6-4862", "06e785fb-b24e", 7,  2,  null,  null),
                new PrintRequestMatchDto(92, 2,  "cd0b820d-15e4", "3b710e93-ee56", 5,  7,  null,  null),
                new PrintRequestMatchDto(93, 2,  "07d32bae-883f", "28075262-79d2", 5,  7,  null,  null),
                new PrintRequestMatchDto(94, 2,  "50bb806b-5f0c", "246662dc-3c9d", 7,  4,  null,  null),
                new PrintRequestMatchDto(95, 2,  "8b7e7a58-8f94", "f6f7b9cf-f875", 5,  7,  null,  null),
                new PrintRequestMatchDto(96, 2,  "eb09da9d-d93a", "b06d8719-e99e", 4,  7,  null,  null),
                new PrintRequestMatchDto(97, 3,  "dc406a44-7967", "4dd29068-eafd", 6,  7,  null,  null),
                new PrintRequestMatchDto(98, 3,  "0e8728db-4f0b", "860f43bb-7e90", 3,  7,  null,  null),
                new PrintRequestMatchDto(99, 3,  "223558ee-c55d", "a4fbce88-ed16", 7,  1,  null,  null),
                new PrintRequestMatchDto(100, 3,  "a8cb2ff2-c94d", "552ebf32-e56c", 5,  7,  null,  null),
                new PrintRequestMatchDto(101, 3,  "3e4eaa42-ee47", "1aeeab5b-2ed0", 2,  7,  null,  null),
                new PrintRequestMatchDto(102, 3,  "f0751703-121f", "ae1d2282-8cf1", 2,  7,  null,  null),
                new PrintRequestMatchDto(103, 3,  "06039899-c1b0", "faa7e4cc-1a51", 1,  7,  null,  null),
                new PrintRequestMatchDto(104, 3,  "92a559dc-ce9f", "5b662886-6262", 0,  7,  null,  null),
                new PrintRequestMatchDto(105, 3,  "ba1779df-7c96", "2262f769-b441", 2,  7,  null,  null),
                new PrintRequestMatchDto(106, 3,  "dd581188-066e", "0b7101be-896e", 7,  4,  null,  null),
                new PrintRequestMatchDto(107, 3,  "b08e38a3-e180", "8a84aaa0-3e9e", 7,  1,  null,  null),
                new PrintRequestMatchDto(108, 3,  "cee76aa9-9a7c", "6572069f-4a57", 7,  6,  null,  null),
                new PrintRequestMatchDto(109, 3,  "cc45c05f-e8ea", "76ab34b2-2830", 2,  7,  null,  null),
                new PrintRequestMatchDto(110, 3,  "adfb90f6-4862", "3b710e93-ee56", 7,  2,  null,  null),
                new PrintRequestMatchDto(111, 3,  "28075262-79d2", "50bb806b-5f0c", 2,  7,  null,  null),
                new PrintRequestMatchDto(112, 3,  "f6f7b9cf-f875", "b06d8719-e99e", 5,  7,  null,  null),
                new PrintRequestMatchDto(113, 4,  "4dd29068-eafd", "860f43bb-7e90", 3,  7,  null,  null),
                new PrintRequestMatchDto(114, 4,  "223558ee-c55d", "552ebf32-e56c", 7,  5,  null,  null),
                new PrintRequestMatchDto(115, 4,  "1aeeab5b-2ed0", "ae1d2282-8cf1", 5,  7,  null,  null),
                new PrintRequestMatchDto(116, 4,  "faa7e4cc-1a51", "5b662886-6262", 2,  7,  null,  null),
                new PrintRequestMatchDto(117, 4,  "2262f769-b441", "dd581188-066e", 1,  7,  null,  null),
                new PrintRequestMatchDto(118, 4,  "b08e38a3-e180", "cee76aa9-9a7c", 7,  6,  null,  null),
                new PrintRequestMatchDto(119, 4,  "76ab34b2-2830", "adfb90f6-4862", 5,  7,  null,  null),
                new PrintRequestMatchDto(120, 4,  "50bb806b-5f0c", "b06d8719-e99e", 7,  3,  null,  null),
                new PrintRequestMatchDto(121, 5,  "860f43bb-7e90", "223558ee-c55d", 4,  7,  null,  null),
                new PrintRequestMatchDto(122, 5,  "ae1d2282-8cf1", "5b662886-6262", 7,  4,  null,  null),
                new PrintRequestMatchDto(123, 5,  "dd581188-066e", "b08e38a3-e180", 6,  7,  null,  null),
                new PrintRequestMatchDto(124, 5,  "adfb90f6-4862", "50bb806b-5f0c", 6,  7,  null,  null),
                new PrintRequestMatchDto(125, 6,  "223558ee-c55d", "ae1d2282-8cf1", null,  null,  null,  null),
                new PrintRequestMatchDto(126, 6,  "b08e38a3-e180", "50bb806b-5f0c", null,  null,  null,  null),
                new PrintRequestMatchDto(127, 7,  null, null, null,  null,  null,  null),
            }
        };
    }
}
