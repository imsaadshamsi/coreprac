using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace coreprac.Services
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>(){
            new Character(),
            new Character {Id = 1, Name = "Sam"}
        };
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CharacterService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var character = _mapper.Map<Character>(newCharacter);
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            var dbCharacters = await _context.Characters.ToListAsync();
             serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();

            // var character = _mapper.Map<Character>(newCharacter);
            // character.Id = characters.Max(c => c.Id) + 1;
            // characters.Add(character);
            // serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try{                
                var dbCharacter = await _context.Characters.FindAsync(id);
                if(dbCharacter is null)
                    throw new Exception($"Character with Id '{id}' not found.");
                
                _context.Characters.Remove(dbCharacter);
                await _context.SaveChangesAsync();
                
                var dbCharacters = await _context.Characters.ToListAsync();
                serviceResponse.Data =  dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();

            // var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            // try{
            //     var character = characters.First(c => c.Id == id);
            //     if(character is null)
            //         throw new Exception($"Character with Id '{id}' not found.");

            //     characters.Remove(character);
                
            //     serviceResponse.Data =  characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            }
            catch(Exception ex){
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        } 

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var dbCharacters = await _context.Characters.ToListAsync();
            // serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
             serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;   
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var dbCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
            // var character = characters.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacter);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {            
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            try{
                 var dbCharacter = await _context.Characters.FindAsync(updatedCharacter.Id);
                 if(dbCharacter is null)
                    throw new Exception($"Character with Id '{updatedCharacter.Id}' not found.");


                dbCharacter.Defense = updatedCharacter.Defense;        
                dbCharacter.HitPoints = updatedCharacter.HitPoints;           
                dbCharacter.Intelligence  = updatedCharacter.Intelligence;          
                dbCharacter.MClass  = updatedCharacter.MClass;          
                dbCharacter.Name  = updatedCharacter.Name;          
                dbCharacter.Strength = updatedCharacter.Strength;

                await _context.SaveChangesAsync();

                var dbReturnCharacter = await _context.Characters.FindAsync(updatedCharacter.Id);

                serviceResponse.Data = _mapper.Map<GetCharacterDto>(dbReturnCharacter);

                // var character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);
                // if(character is null)
                //     throw new Exception($"Character with Id '{updatedCharacter.Id}' not found.");

                // _mapper.Map(updatedCharacter, character);

                // character.Defense = updatedCharacter.Defense;        
                // character.HitPoints = updatedCharacter.HitPoints;           
                // character.Intelligence  = updatedCharacter.Intelligence;          
                // character.MClass  = updatedCharacter.MClass;          
                // character.Name  = updatedCharacter.Name;          
                // character.Strength = updatedCharacter.Strength;

                // serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch(Exception ex){
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}