using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesData : MonoBehaviour
{
    public static string[,] westSceneMonsters = new string[,] {
	//[0]NO,[1] name,              [2] HP, [3]MP, [4]attack, [5]guarg, [6]ag, [7]enemy_type, [8] drop_no, [9] get_exp, [10] get_money, [11] drop_probability_type
	{ "-3", "ぬし",                  "24", "10", "7", "4", "4", "2", "27", "15", "30","0"},
        { "0", "ちんぴら",               "10", "0", "4", "3", "2", "0", "17", "4", "4","1"},
        { "1", "こわいひと",             "9", "0", "6","2", "2", "0", "18", "4", "10","2"},
        { "2", "おくすりまん",           "10", "3", "4","2", "1", "0", "17", "4", "4","1"},
        { "4", "しゅうきょうか",         "15", "10", "1", "1", "4", "1", "3", "5", "10","3"},
        { "5", "きぎょうせんし",         "8", "0", "5", "2", "1", "0", "12", "5", "10","1"},
        { "6", "げんきなこども",         "7", "0", "3", "1", "5", "0", "8", "3", "1","3"},
        { "7", "うるさいおばさん",       "13", "3", "3", "3", "2", "1", "21", "4", "3","1"},
        { "8", "よっぱらい",             "10", "0", "5", "4", "0", "0", "7", "6", "6","2"},
        { "9", "けもの",                 "12", "0", "6", "0", "6", "0", "1", "8", "0","2"},
    };
    public static string[,] eastSceneMonsters = new string[,] {
        { "0", "がくせい",              "15", "0", "8", "6", "4", "0", "2", "20", "8","1"},
        { "1", "トんだおじさん",        "16", "2", "10", "6", "2", "0", "17", "10", "4","1"},
        { "2", "うるさいおばさんV2",    "22", "2", "4", "6", "3", "1", "12", "12", "8","2"},
        { "3", "かみつきがめ",          "18", "0", "7", "12", "3", "0", "6", "5", "6","3"},
        { "4", "からす",                "10", "0", "13", "0", "6", "0", "1", "7", "0","1"},
        { "5", "こうこうせい",          "10", "0", "7", "7", "4", "0", "16", "6", "2","3"},
    };
    public static string[,] dendai2_1SceneMonsters = new string[,] {
        { "-3", "GOD",                  "120", "77", "40", "25", "0", "3", "28", "777", "77777","0"},
        { "0", "でんだいせい",          "19", "2", "11", "7", "5", "0", "2", "11", "6","2"},
        { "1", "うぇい",                "18", "2", "13", "9", "5", "0", "2", "12", "10","1"},
        { "2", "いんきゃ",              "21", "6", "9", "9", "1", "0", "3", "11", "8","3"},
        { "3", "せいそういん",          "22", "6", "9", "8", "3", "0", "5", "14", "13","3"},
        { "4", "かーどげーまー",        "16", "20", "4", "7", "4", "1", "19", "13", "5","2"},
        { "5", "くさいがくせい",        "25", "3", "7", "13", "0", "0", "15", "20", "2","0"},
    };
    public static string[,] dendai2_2SceneMonsters = new string[,] {
        { "-3", "上級でんだいせい",     "50", "20", "15", "15", "5", "2", "24", "40", "40","0"},
        { "0", "でんだいせいV2",        "25", "4", "13", "10", "5", "0", "23", "13", "15","1"},
        { "1", "うぇいV2",              "23", "4", "16", "7", "6", "0", "13", "14", "14","1"},
        { "2", "いんきゃV2",            "26", "8", "11", "11", "1", "0", "7", "15", "13","2"},
        { "3", "じゅんきょうじゅ",      "27", "7", "15", "8", "2", "0", "20", "16", "25","3"},
        { "4", "かーどげーまーV2",      "20", "30","10", "12", "2", "0", "2", "15", "1","2"},
        { "5", "ほもがき",              "30", "0", "9", "15", "5", "1", "2", "10", "1","2"},
    };
    public static string[,] dendai1_1SceneMonsters = new string[,] {
        { "-3", "がっかたんとう",       "55", "30", "20","15", "8", "2", "20", "50", "60","0"},
        { "0", "けんきゅうせい",        "27", "5", "14", "11", "5", "0", "2", "15", "15","1"},
        { "1", "りゅうねんせい",        "25", "4", "18", "8", "2", "0", "4", "16", "16","0"},
        { "2", "ざんりゅうとどけ",      "23", "10", "24", "9", "1", "0", "16", "17", "17","2"},
        { "3", "レポートたんとう",      "23", "10", "18", "11", "9", "0", "19", "8", "12","2"},
        { "4", "おきゃくさま",          "5", "5", "5", "5", "5", "0", "22", "5", "-50","1"},
    };
    public static string[,] dendai1_2SceneMonsters = new string[,] {
        { "0", "けんきゅうせいV2",      "30", "6", "17", "12", "6", "0", "5", "18", "18","2"},
        { "1", "りゅうねんせいV2",      "32", "6", "18", "10", "7", "0", "3", "19", "10","0"},
        { "2", "ざんりゅうとどけV2",    "20", "20", "25", "7", "5", "0", "16", "20", "10","2"},
        { "3", "レポートたんとうV2",    "31", "10","20", "10", "8", "1", "9", "30", "25","2"},
        { "4", "おきゃくさまV2",        "3", "3", "3", "3", "3", "0", "14", "3", "-100","2"},
    };
    public static string[,] dendai1_3SceneMonsters = new string[,] {
        { "-3", "マスクドADACHI",       "80", "100", "27", "25", "10", "3", "17", "200", "200","0"},
        { "0", "研究おわらん",          "31", "8", "20", "10", "7", "0", "4", "20", "20","3"},
        { "1", "留年3年目",             "40", "20","17",  "14","5", "0", "9", "20", "25","0"},
        { "2", "残留3日目",             "25", "30", "26", "5", "3", "1", "16", "25", "30","3"},
        { "3", "お客様",                "1", "1", "1", "1", "1", "1", "12", "14", "-150","1"},
        { "4", "教授",                  "35", "12", "22", "14", "7", "0", "7", "30", "50","3"},
    };

    public static string[,] mainSceneMonsters = new string[,] {
		//[0]NO, [1] name, [2] HP, [3]MP, [4]attack, [5]guarg, [6]ag, [7]enemy_type, [8] drop_no, [9] get_exp, [10] get_money, [11] drop_probability_type
		{ "0", "スライム",              "5","0","2","2","3","0","1","1","1","1"},
        { "1", "もりのようせい",        "12", "0","8","4","1","0","1","1","5","2"},
        { "2", "ありせんし",            "7", "0","6","3","4","1","2","2","2","3"},
    };

    public static string[,] GetMonsterList(string sceneName)
    {
        switch (sceneName)
        {
            case "map_west":
                return westSceneMonsters;
            case "map_east":
                return eastSceneMonsters;
            case "map_dendai2_1":
                return dendai2_1SceneMonsters;
            case "map_dendai2_2":
                return dendai2_2SceneMonsters;
            case "map_dendai1_1":
                return dendai1_1SceneMonsters;
            case "map_dendai1_2":
                return dendai1_2SceneMonsters;
            case "map_dendai1_3":
                return dendai1_3SceneMonsters;
            default:
                return mainSceneMonsters;
        }
    }
}