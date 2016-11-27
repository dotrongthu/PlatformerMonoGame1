#ifndef ENCODINGTABLE_H
#define ENCODINGTABLE_H

#ifdef FAMILYHEARTMETHODTOTALLYNORMALNOTENCODE_EXPORTS
#define FAMILYHEARTMETHODTOTALLYNORMALNOTENCODE_API extern "C"  __declspec(dllexport)
#else
#define FAMILYHEARTTOTALLYNORMALNOTHINGENCODE_API extern "C"  __declspec(dllimport)
#endif



namespace FamilyheartEncoding {

		//The number code for transforming
	FAMILYHEARTMETHODTOTALLYNORMALNOTENCODE_API int fullTableCodeNumber[14][18];

		//Convert text to Familyheartdecode
	FAMILYHEARTMETHODTOTALLYNORMALNOTENCODE_API bool ConvertText(char* path);

	FAMILYHEARTMETHODTOTALLYNORMALNOTENCODE_API void LoadDecodeFile(const char* path);

	FAMILYHEARTMETHODTOTALLYNORMALNOTENCODE_API void SaveEncodeFile(const char* path);

}


#endif