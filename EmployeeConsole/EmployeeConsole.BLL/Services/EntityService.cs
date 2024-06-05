//using System.Collections.Generic;
//using AutoMapper;
//using Employee.WebApi.DAL.Interfaces;
//using Employee.WebApi.BLL.Interfaces;
//using Employee.WebApi.Models.Model;
//using Employee.WebApi.Models.DataTransferObjects;

//namespace Employee.WebApi.BLL.Services
//{
//    public class GenericEntityService<TEntity, TDto> : IEntityService<TDto> where TEntity : class where TDto : class
//    {
//        private readonly IDbService _dbService;
//        private readonly IMapper _mapper;

//        public GenericEntityService(IDbService dbService, IMapper mapper)
//        {
//            _dbService = dbService;
//            _mapper = mapper;
//        }

//        public List<TDto> DisplayAll()
//        {
//            var entities = _dbService.DisplayAll<TEntity>();
//            return _mapper.Map<List<TDto>>(entities);
//        }

//        public bool AddEntity(TDto entityDto)
//        {
//            var entity = _mapper.Map<TEntity>(entityDto);
//            return _dbService.AddEntity(entity);
//        }

//        public bool IsEntityNameExists(string entityName)
//        {
//            return _dbService.IsEntityExists<TEntity>(entity => entity.Name == entityName);
//        }
//    }
//}
