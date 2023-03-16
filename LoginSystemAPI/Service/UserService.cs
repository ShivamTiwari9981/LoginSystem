using LoginSystemAPI.Model;
using LoginSystemAPI.UnitOfWork;
using Microsoft.Data.SqlClient;
using System.Data;

namespace LoginSystemAPI.Service
{

    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService()
        {
            _unitOfWork = new UnitOfWork.UnitOfWork();
        }
        #region User
        public DataSet AddUser(UserViewModel model)
        {
            try
            {
                var param = new List<SqlParameter>
                {
                    new SqlParameter("@user_name", model.UsrNam),
                    new SqlParameter("@user_pwd", model.UsrPwd),
                    new SqlParameter("@user_mobile", model.UsrMobile),
                    new SqlParameter("@user_email", model.UsrEmail),
                    //new SqlParameter("@user_type", model.UsrType),
                    new SqlParameter("@role_id", model.RoleId),
                    //new SqlParameter("@err_no", SqlDbType.Int,err),
                };
                var result = Global.ExecuteStoredProcedure("sp_add_user", param, _unitOfWork.GetConnection());
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Account
        public LoginSessionModel AuthenticateUser(LoginViewModel model)
        {
            try
            {
                var param = new List<SqlParameter>
                {
                    new SqlParameter("@user_nam", model.UsrNam),
                    new SqlParameter("@password", model.UsrPwd),
                    //new SqlParameter("@err_no", SqlDbType.Int,err),
                };
                var result = Global.ExecuteStoredProcedure("sp_login", param, _unitOfWork.GetConnection());
                LoginSessionModel? loginSessionModel = Global.CommonMethod.ConvertToList<LoginSessionModel>(result.Tables[0]).FirstOrDefault();
                return loginSessionModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool SignUpUser(UserViewModel model)
        {
            try
            {
                string userPassword = string.Empty;
                bool IsSuccess = false;
                var param = new List<SqlParameter>
                {
                    new SqlParameter("@user_name", model.UsrNam),
                    new SqlParameter("@user_pwd", userPassword),
                    new SqlParameter("@user_mobile", model.UsrMobile),
                    new SqlParameter("@user_email", model.UsrEmail),
                    new SqlParameter("@role_id", model.RoleId),
                };
                var result = Global.ExecuteStoredProcedure("sp_add_user", param, _unitOfWork.GetConnection());
                int res = Convert.ToInt32(result.Tables[0].Rows[0].ItemArray[0]);
                if (res == 0)
                    IsSuccess = true;
                return IsSuccess;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Module
        public ResponseModel GetAllModule(string userType)
        {
            try
            {
                var moduleList = new List<ModuleViewModel>();
                var subModuleList = new List<SubModuleViewModel>();
                ResponseModel responseModel = new ResponseModel();
                var param = new List<SqlParameter>
                {
                    new SqlParameter("@user_type", userType),
                };
                var result = Global.ExecuteStoredProcedure("sp_view", param, _unitOfWork.GetConnection());
                if (result.Tables.Count > 0)
                {
                    moduleList = Global.CommonMethod.ConvertToList<ModuleViewModel>(result.Tables[0]);
                    subModuleList = Global.CommonMethod.ConvertToList<SubModuleViewModel>(result.Tables[1]);
                    int i = 0;
                    foreach(var m in moduleList)
                    {
                        ModuleViewModel module = new ModuleViewModel();
                        module.subModule = subModuleList.Where(x => x.module_id == m.module_id).ToList();
                        moduleList[i].subModule = module.subModule;
                        i++;
                    }
                }
                responseModel.status = true;
                responseModel.data = moduleList;
                responseModel.message = "Success";
                return responseModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        
    }

}
