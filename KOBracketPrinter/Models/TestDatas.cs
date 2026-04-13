namespace KOBracketPrinter.Models;

public class TestDatas
{
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
}
