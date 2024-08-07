﻿namespace AyodhyaYatra.API.Contants
{
    public static class StaticValues
    {
        #region API Paths
        public const string APIPrefix = "v1/[controller]";

        #region Login API
        public const string LoginPath = "user/login";
        public const string LoginUserRegisterPath = "user/register";
        public const string LoginUserChangePasswordPath = "user/change/password";
        public const string LoginUserResetPasswordPath = "user/reset/password";
        public const string LoginUserUpdateProfilePath = "user/update/profile";
        public const string LoginUserDeleteProfilePath = "user/delete/profile/{email}";
        public const string UserBlockPath = "user/block/{email}";
        public const string UserAssignRolePath = "user/update/{email}/{role}";
        public const string UserResetEmailVerifyCodePath = "user/update/verify/code/{email}";
        public const string LoginUserVerifyEmailPath = "user/verify/email/{token}";
        #endregion

        #region Master Data API
        public const string MasterGetYatraPath = "get/yatras";
        public const string MasterYatraGetByIdPath = "yatra/get/{id}";
        public const string MasterGetSequencePath = "get/sequences";

        public const string MasterDivisionPath = "divisions";
        public const string MasterDataPath = "master/data";
        public const string MasterDataGetByTypesPath = "master/data/types";
        public const string MasterDataDropdownPath = "master/data/dropdown";
        public const string MasterDataByIdPath = "master/data/{id}";
        public const string MasterYatraPath = "yatras";
        public const string MasterSequencePath = "sequences";
        public const string MasterDataNearByPlacesPath = "master/nearby/data";
        public const string MasterDataSearchPath = "master/search";

        #endregion

        #region Charity
        public const string CharityPath = APIPrefix;
        public const string CharityGetByIdPath = APIPrefix+"/get/by/id/{id}";
        public const string CharityMasterPath = APIPrefix+"/master";
        public const string CharityMasterGetByIdPath = APIPrefix + "/master/get/by/id/{id}";

        #endregion

        #region Master Attraction
        public const string MasterAttractionPath = "master/attraction";
        public const string MasterAttractionGetByIdPath = "master/attraction/get/{id}";
        public const string MasterAttractioneGetByIdOrBarcodeIdPath = "master/attraction/barcode/get/{barcodeId}";
        public const string MasterAttractionGetByYatraIdPath = "master/attraction/get/yatra/{yatraId}";
        public const string MasterAttractionGetByTypeIdPath = "master/attraction/get/type/{typeId}";
        public const string MasterAttractionSearchPath = "master/attraction/search";
        public const string MasterAttractionDeletePath = "master/attraction/delete/{id}";
        public const string GenerateMasterAttractionQrCodePath = "master/attraction/generate/qr/code";
        public const string MasterAttractionUpdateFromExcelPath = "master/attraction/update/excel";
        public const string MasterAttractionGetByIdOrBarcodeIdPath = "master/attraction/get/by/id/barcode";
        public const string SpecificMasterAttractionPath = "master/attraction/get";

        public const string MasterAttractionTypePath = "master/attraction/type";
        public const string MasterAttractionTypeSearchPath = "master/attraction/type/search";
        public const string MasterAttractionTypeDeletePath = "master/attraction/type/delete/{id}";
        public const string MasterAttractionTypeGetByCodePath = "master/attraction/type/get/code";
        public const string MasterAttractionTypeGetByIdPath = "master/attraction/type/get/{id}";

        public const string MasterAttractionYatraMapperPath = "master/attraction/yatra/mapper";
        public const string MasterAttractionYatraMapperSearchPath = "master/attraction/yatra/mapper/search";
        public const string MasterAttractionYatraMapperDeletePath = "master/attraction/yatra/mapper/delete/{id}";
        public const string MasterAttractionYatraMapperGetByYatraIdPath = "master/attraction/yatra/mapper/get/by/yatra";
        public const string MasterAttractionYatraMapperGetByIdPath = "master/attraction/yatra/mapper/get/{id}";

        public const string VisitorAddDocTypePath = "visitors/add/doctype";
        public const string VisitorAddPath = "visitors/add";
        public const string VisitorDeleteDocTypePath = "visitors/delete/doctype/{id}";
        public const string VisitorGetDocTypePath = "visitors/get/doctype";
        public const string VisitorGetPath = "visitors/get";
        public const string VisitorGetByMobilePath = "visitors/get/by/mobile";
        public const string VisitorGetCountPath = "visitors/get/count";
        public const string VisitorValidatePath = "visitors/get/validate";
        public const string VisitorUpdateDocTypePath = "visitors/update/doctype";
        #endregion

        #region Image Upload
        public const string FileUploadPath = "upload";
        public const string FileGetImageByModNameModIdPath = "image/get/modname/id";
        public const string FileGetImageByModNameModNamePath = "image/get/modname";
        public const string FileGetImageByModNameModIdsPath = "image/get/modname/ids";
        public const string FileGetImageByModNameModIdSeqPath = "image/get/modname/id/seq";
        public const string FileGetImageByModNamePagingPath = "image/get/modname/paging";
        public const string FileDeleteImageByIdPath = "image/delete/id";
        public const string FileDeleteExistingThumbAndGenerateNewThumbPath = "image/delete/exist/generate/new/thumb";
        #endregion

        #region Mobile API
        public const string MobileAttractionPath = "mobile/master/attractions";
        #endregion

        #endregion

        #region Error Type Message
        public const string ErrorType_InvalidDataSupplied = "InvalidDataSupplied";
        public const string ErrorType_NoDataSupplied = "NoDataSupplied";
        public const string ErrorType_InvalidCredentials = "InvalidCredentials";
        public const string ErrorType_UserAccountBlocked = "UserAccountBlocked";
        public const string ErrorType_UserAccountLocked = "UserAccountLocked";
        public const string ErrorType_UserAccountEmailNotVerified = "UserAccountEmailNotVerified";
        public const string ErrorType_InvalidConfigData = "InvalidConfigData"; 
        public const string ErrorType_UserNotFound = "UserNotFound";
        public const string ErrorType_InvalidModuleName = "InvalidModuleName";
        public const string ErrorType_ImageNotSelected = "ImageNotSelected";
        public const string ErrorType_RecordNotFound = "RecordNotFound";
        public const string ErrorType_CodeIsAlreadyExist = "CodeIsAlreadyExist";
        public const string ErrorType_AlreadyDeleted = "AlreadyDeleted";
        public const string ErrorType_AlreadyExist = "AlreadyExist";
        public const string ErrorType_InvalidGovDocType = "InvalidGovDocType";
        public const string ErrorType_InvalidGovDocNo = "InvalidGovDocNo";
        public const string ErrorType_EmailAlreadyVerified = "EmailAlreadyVerified";
        #endregion

        #region Error Message
        public const string Error_InvalidGovDocType = "Invalid government document type.";
        public const string Error_InvalidGovDocNo = "Invalid governmentdocument number.";
        public const string Error_InvalidDataSupplied = "Invalid data supplied";
        public const string Error_CodeIsAlreadyExist = "Code is already exist";
        public const string Error_NoDataSupplied = "No data supplied";
        public const string Error_InvalidCredentials = "Wrong username/password";
        public const string Error_UserNotFound = "User is not registered.";
        public const string Error_InvalidOldPassword = "Wrong old password";
        public const string Error_UserAccountBlocked = "User account is blocked";
        public const string Error_UserAccountLocked = "User account is locked";
        public const string Error_UserAccountEmailNotVerified = "User account email is not verified";
        public const string Error_InvalidConfigData = "Some appSetting config key missing/contains invalid data";
        public const string Error_InvalidModuleName = "Invalid modile name";
        public const string Error_ImageNotSelected = "Image not selected";
        public const string Error_RecordNotFound = "Record not found";
        public const string Error_AlreadyDeleted = "Record is already deleted";
        public const string Error_AlreadyExist = "Record is already exist";
        public const string Error_EmailAlreadyRegistered = "This email is already registered";
        public const string Error_EmailAlreadyVerified = "This email is already verified";
        #endregion

        #region Constant Values
        #endregion
    }
}
