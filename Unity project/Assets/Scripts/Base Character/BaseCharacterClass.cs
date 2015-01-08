using UnityEngine;
using System.Collections.Generic;

public class BaseCharacterClass {

	// NAME AND DESCRIPTION
	private string characterClassName;
	private string characterClassDescription;

	// STATS
	private int ruby;
	private int javaScript;
	private int sQL;
	private int keyboardShortcuts;
	private int security;

	// GETTERS AND SETTERS

	// NAME AND DESCRIPTION
	public string CharacterClassName { get; set; }
	public string CharacterClassDescription { get; set; }
	// STATS
	public int Ruby { get; set; }
	public int JavaScript { get; set; }
	public int SQL { get; set; }
	public int KeyboardShortcuts { get; set; }
	public int Security { get; set; }

	public BaseAbility SpecialAblity{get;set;}
	
}