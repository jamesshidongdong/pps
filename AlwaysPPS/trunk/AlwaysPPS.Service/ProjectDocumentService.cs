using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlwaysFramework.DAL;
using AlwaysPPS.Entity;

namespace AlwaysPPS.Service
{
    public interface IProjectDocumentService
    {
        List<CtDocumentType> GetAllDocumentType();

        List<TProjectDocument> GetAllDocuments(int ProjectId);
        bool AddProjectDocument(TProjectDocument entity);
        bool UpdateProjectDocument(TProjectDocument entity);
        bool DeleteProjectDocument(int Id);

        TProjectDocument GetDocumentTypeByID(int id);
    }

    public class ProjectDocumentService : IProjectDocumentService
    {
        private readonly IRepository<CtDocumentType> _docType;
        private readonly IRepository<TProjectDocument> _doc;

        public ProjectDocumentService(IRepository<CtDocumentType> docType, IRepository<TProjectDocument> doc)
        {
            this._doc = doc;
            this._docType = docType;
        }

        //文件类型
        public List<CtDocumentType> GetAllDocumentType()
        {
            return _docType.Query().Get().ToList();
        }

        //当前项目文件集合(未删除)
        public List<TProjectDocument> GetAllDocuments(int ProjectId)
        {
            var model = _doc.Query().Filter(x => x.ProjectId == ProjectId && x.Deleted!=true).Get().ToList();
            List<TProjectDocument> list=new List<TProjectDocument>();
            foreach (var e in model)
            {
                e.DocumentFileName = ConfigurationManager.AppSettings["domainUrl"]+e.DocumentFileName;
                list.Add(e);
            }
            return list;
        }
        //新增
        public bool AddProjectDocument(TProjectDocument entity)
        {
            _doc.Insert(entity);
            return true;
        }
        //修改
        public bool UpdateProjectDocument(TProjectDocument entity)
        {
            _doc.Update(entity);
            return true;
        }
        //删除
        public bool DeleteProjectDocument(int Id)
        {
            var model = _doc.Query().Filter(x => x.DocumentId == Id).Get().FirstOrDefault();
            if (model != null)
            {
                model.Deleted = true;
                _doc.Update(model);
                return true;
            }
            else
            {
                throw new Exception("参数错误");
            }
        }

        public TProjectDocument GetDocumentTypeByID(int id)
        {
            return _doc.Query().Filter(u => u.DocumentId == id).Get().FirstOrDefault();
        }

    }
}
