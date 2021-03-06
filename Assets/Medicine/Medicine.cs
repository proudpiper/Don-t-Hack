﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class Medicine {
	public static string albuterolMapping = 
		KeyCodeMapper.KeyCodeToString (InputMapping.upCode) +
		KeyCodeMapper.KeyCodeToString (InputMapping.upCode) +
		KeyCodeMapper.KeyCodeToString (InputMapping.rightCode) +
		KeyCodeMapper.KeyCodeToString (InputMapping.rightCode) +
		KeyCodeMapper.KeyCodeToString (InputMapping.leftCode);

	public static string singulairMapping = 
		KeyCodeMapper.KeyCodeToString (InputMapping.rightCode) +
		KeyCodeMapper.KeyCodeToString (InputMapping.downCode) +
		KeyCodeMapper.KeyCodeToString (InputMapping.leftCode) +
		KeyCodeMapper.KeyCodeToString (InputMapping.upCode) +
		KeyCodeMapper.KeyCodeToString (InputMapping.rightCode);

	public static string epinephrinMapping = 
		KeyCodeMapper.KeyCodeToString (InputMapping.rightCode) +
		KeyCodeMapper.KeyCodeToString (InputMapping.rightCode) +
		KeyCodeMapper.KeyCodeToString (InputMapping.downCode) +
		KeyCodeMapper.KeyCodeToString (InputMapping.upCode) +
		KeyCodeMapper.KeyCodeToString (InputMapping.leftCode);

	public static string tissueMapping =
		KeyCodeMapper.KeyCodeToString(InputMapping.downCode) +
		KeyCodeMapper.KeyCodeToString(InputMapping.rightCode) +
		KeyCodeMapper.KeyCodeToString(InputMapping.downCode) +
		KeyCodeMapper.KeyCodeToString(InputMapping.rightCode) +
		KeyCodeMapper.KeyCodeToString(InputMapping.upCode);

	public static Dictionary<string, Medicine_Reference> patternDerefernecer = new Dictionary<string, Medicine_Reference>();

	public static void SetupMedicineDereferencer(Player player){
		patternDerefernecer.Add (albuterolMapping, new Medicine_Reference (5, 10, player.AlbuterolUpdateCallback));
		patternDerefernecer.Add (singulairMapping, new Medicine_Reference (5, 25, player.SingulairUpdateCallback));
		patternDerefernecer.Add (epinephrinMapping, new Medicine_Reference (5,  50, player.EpenephrinUpdateCallback));
		patternDerefernecer.Add (tissueMapping, new Medicine_Reference (5,  5, player.TissueUpdateCallback));
	}
}

